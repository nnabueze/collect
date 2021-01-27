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

            private readonly IGenericRepository<Batch> _batchResponsitory;

            private readonly IMapper _mapper;

            private readonly ITransactionRepository _transactionRepository;

            private readonly ResponseCode _response;

            private readonly IGenericRepository<CategoryTwoService> _categoryTwoServiceRepository;

            public FlexSettlementCommandHandler(ISettlementRepository settlementRepository, IMapper mapper,

                ITransactionRepository transactionRepository, IOptions<ResponseCode> response,

                IGenericRepository<Biller> billerRepository, IGenericRepository<Batch> batchResponsitory, IGenericRepository<CategoryTwoService> categoryTwoServiceRepository)
            {
                _settlementRepository = settlementRepository;

                _mapper = mapper;

                _transactionRepository = transactionRepository;

                _response = response.Value;

                _billerRepository = billerRepository;

                _batchResponsitory = batchResponsitory;

                _categoryTwoServiceRepository = categoryTwoServiceRepository;
            }
            public async Task<SuccessfulResponse> Handle(FlexSettlementCommand request, CancellationToken cancellationToken)
            {
                //automapper
                Biller biller = GetBiller(request);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Wrong Biller Id", _response.NotFound, false, request.FlexSettlementDto);
                }

                Settlement addSettlement = await SaveSettlement(request, biller);

                var savedBatch = await SaveBatch(request, biller);

                await SaveTransaction(request, addSettlement, savedBatch);

                return ResponseGenerator.Response("Transaction Accepted", _response.OK, true);

            }

            private Biller GetBiller(FlexSettlementCommand request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request.FlexSettlementDto.BillerId);
            }

            public async Task<Batch> SaveBatch(FlexSettlementCommand request, Biller biller)
            {
                var batch = new Batch()
                {
                    TotalAmount = Convert.ToDecimal(request.FlexSettlementDto.TotalAmount),

                    BillerId = biller.Id,

                    ItemCount = 1,

                    PaymentChannel = PaymentChannels.Card,

                    ReferenceKey = request.FlexSettlementDto.ReferenceNumber,

                    IsSuccess = request.FlexSettlementDto.IsSuccess,

                    TransactionType = TypesOfTransaction.SelfService
                    
                };

                var savedBatch = await _batchResponsitory.Add(batch);

                return savedBatch;
            }

            private async Task<Settlement> SaveSettlement(FlexSettlementCommand request, Biller biller)
            {

                var settlement = new Settlement()
                {

                    Amount = Convert.ToDecimal(request.FlexSettlementDto.TotalAmount),

                    BillerId = biller.Id,

                    PaidBy = request.FlexSettlementDto.PayerName,

                    PayerPhone = request.FlexSettlementDto.PayerPhone,

                    PaymentChannel = PaymentChannels.Card,

                    ReferenceID = request.FlexSettlementDto.ReferenceNumber,

                    TransactionNumber = request.FlexSettlementDto.TransactionNumber,

                    TransactionType = TypesOfTransaction.SelfService

                };

                var addSettlement = await _settlementRepository.Add(settlement);

                await _settlementRepository.CommitAsync();

                return addSettlement;
            }

            private async Task SaveTransaction(FlexSettlementCommand request, Settlement addSettlement, Batch batch)
            {
                foreach (var item in request.FlexSettlementDto.transactionItems)
                {
                    var categoryTwoId = _categoryTwoServiceRepository.FindFirst(x => x.ReferenceKey == item.CategoryTwoId).Id;

                    var transaction = new Transaction()
                    {
                        Amount = item.Amount,

                        CategoryTwoServiceId = categoryTwoId,

                        PayerName = addSettlement.PaidBy,

                        PayerPhone = addSettlement.PayerPhone,

                        ReferenceKey = addSettlement.TransactionNumber,

                        BatchReferenceKey = batch.ReferenceKey

                    };

                    await _transactionRepository.Add(transaction);
                }

                await _transactionRepository.CommitAsync();
            }
        }
    }
}
