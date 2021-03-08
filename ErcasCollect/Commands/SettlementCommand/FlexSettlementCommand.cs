using AutoMapper;
using ErcasCollect.Commands.Dto.SettlementDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Helpers.EnumClasses;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.SettlementCommand
{
    public class FlexSettlementCommand : IRequest<SuccessfulResponse>
    {
        public FlexSettlementDto FlexSettlementDto { get; set; }

        public class FlexSettlementCommandHandler : IRequestHandler<FlexSettlementCommand, SuccessfulResponse>
        {
            private readonly ISettlementRepository _settlementRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<CloseBatchTransaction> _closeBatchTransactionResponsitory;

            private readonly IGenericRepository<Batch> _batchResponsitory;

            private readonly IGenericRepository<Transaction> _transactionResponsitory;

            private readonly IMapper _mapper;

            private readonly ResponseCode _response;

            public FlexSettlementCommandHandler(ISettlementRepository settlementRepository, IGenericRepository<Biller> billerRepository,

                IGenericRepository<CloseBatchTransaction> closeBatchTransactionResponsitory, IMapper mapper, IOptions<ResponseCode> response, 
                
                IGenericRepository<Batch> batchResponsitory, IGenericRepository<Transaction> transactionResponsitory)
            {
                _settlementRepository = settlementRepository;

                _billerRepository = billerRepository;

                _closeBatchTransactionResponsitory = closeBatchTransactionResponsitory;

                _mapper = mapper;

                _response = response.Value;

                _batchResponsitory = batchResponsitory;

                _transactionResponsitory = transactionResponsitory;
            }

            public async Task<SuccessfulResponse> Handle(FlexSettlementCommand request, CancellationToken cancellationToken)
            {
                //automapper

                //varification

                if (request.FlexSettlementDto.IsSuccess)
                {
                    Biller biller = await GetBiller(request);

                    if (biller == null)
                    {
                        return ResponseGenerator.Response("Wrong Biller Id", _response.NotFound, false, request.FlexSettlementDto);
                    }

                    await SaveSettlement(request, biller);

                    var savedClosed = await SaveCloseBatchTransaction(request, biller);

                    var savedBatch = await SaveBatch(request, biller, savedClosed.Id);

                    await SaveTransaction(request, savedBatch.Id, biller);

                    return ResponseGenerator.Response("Transaction Accepted", _response.OK, true, new { ClosedBatchTransactionId = savedClosed.ReferenceKey});
                }

                return ResponseGenerator.Response("Transaction is not successful", _response.NotAccepted, false);

            }

            private async Task<CloseBatchTransaction> SaveCloseBatchTransaction(FlexSettlementCommand request, Biller biller)
            {
                var saveCloseTransaction = new CloseBatchTransaction()
                {
                     BillerId = biller.Id,

                     IsPaid = true,

                     PaymentChannelId = 3,

                     ReferenceKey = JsonXmlObjectConverter.GetBillerRandomString(biller.Abbreviation, 15),

                     TotalAmount = Convert.ToDecimal(request.FlexSettlementDto.TotalAmount)                     
                };

                var saveClosedBatch = await _closeBatchTransactionResponsitory.Add(saveCloseTransaction);

                await _closeBatchTransactionResponsitory.CommitAsync();

                return saveClosedBatch;
            }

            private async Task<Biller> GetBiller(FlexSettlementCommand request)
            {
                return await _billerRepository.FindSingleInclude(x => x.ReferenceKey == request.FlexSettlementDto.BillerId, x => x.CategoryTwoService);
            }

            private async Task<Settlement> SaveSettlement(FlexSettlementCommand request, Biller biller)
            {

                var settlement = new Settlement()
                {

                    Amount = Convert.ToDecimal(request.FlexSettlementDto.TotalAmount),

                    BillerId = biller.Id,

                    PaidBy = request.FlexSettlementDto.PayerName,

                    PayerPhone = request.FlexSettlementDto.PayerPhone,

                    PaymentChannelId = 3,

                    ReferenceID = request.FlexSettlementDto.ReferenceNumber,

                    TransactionNumber = request.FlexSettlementDto.TransactionNumber,

                    TransactionTypeId = 6,

                    IsSuccess = request.FlexSettlementDto.IsSuccess

                };

                var addSettlement = await _settlementRepository.Add(settlement);

                await _settlementRepository.CommitAsync();

                return addSettlement;
            }

            private CategoryTwoService GetCategoryTwoDetail(ICollection<CategoryTwoService> categoryTwo, string categoryTwoId)
            {
                return categoryTwo.ToList().Find(x => x.ReferenceKey == categoryTwoId);
            }

            private async Task<Batch> SaveBatch(FlexSettlementCommand request, Biller biller, int CloseBatchTransactionId)
            {
                CategoryTwoService categoryTwoDetail = GetSpecificCategoryTwo(request, biller);

                var batch = new Batch()
                {
                    BillerId = biller.Id,

                    CloseBatchTransactionId = CloseBatchTransactionId,

                    CreatedDate = DateTime.UtcNow,

                    IsBatchClosed = true,

                    IsSuccess = true,

                    ItemCount = request.FlexSettlementDto.transactionItems.Count(),

                    LevelOneId = categoryTwoDetail.LevelOneId,

                    PaymentChannelId = 3,

                    TotalAmount = request.FlexSettlementDto.transactionItems.Sum(x => x.Amount),

                    TransactionTypeId = 6,

                    ReferenceKey = JsonXmlObjectConverter.GetBillerRandomString(biller.Abbreviation, 15)

                };

                var savedBatch = await _batchResponsitory.Add(batch);

                await _batchResponsitory.CommitAsync();

                return savedBatch;
            }

            private CategoryTwoService GetSpecificCategoryTwo(FlexSettlementCommand request, Biller biller)
            {
                CategoryTwoService categoryTwoDetail = null;

                foreach (var item in request.FlexSettlementDto.transactionItems)
                {
                    categoryTwoDetail = GetCategoryTwoDetail(biller.CategoryTwoService, item.CategoryTwoId);

                    if (categoryTwoDetail != null && categoryTwoDetail.LevelOneId != null)
                    {
                        break;
                    }
                }

                return categoryTwoDetail;
            }

            private async Task SaveTransaction(FlexSettlementCommand request, int batchId, Biller biller)
            {
                foreach (var item in request.FlexSettlementDto.transactionItems)
                {
                    var categoryTwo = GetCategoryTwoDetail(biller.CategoryTwoService, item.CategoryTwoId);

                    var transaction = new Transaction()
                    {
                        Amount = item.Amount,

                        BatchId = batchId,

                        CategoryTwoServiceId = categoryTwo.Id,

                        CreatedDate = DateTime.UtcNow,

                        PayerName = request.FlexSettlementDto.PayerName,

                        PayerPhone = request.FlexSettlementDto.PayerPhone,

                        ReferenceKey = JsonXmlObjectConverter.GetBillerRandomString(biller.Abbreviation, 15)
                    };

                    await _transactionResponsitory.Add(transaction);
                }

                await _transactionResponsitory.CommitAsync();
            }
        }
    }
}
