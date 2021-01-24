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

            public FlexSettlementCommandHandler(ISettlementRepository settlementRepository, IMapper mapper,

                ITransactionRepository transactionRepository, IOptions<ResponseCode> response, 
                
                IGenericRepository<Biller> billerRepository, IGenericRepository<Batch> batchResponsitory)
            {
                _settlementRepository = settlementRepository;

                _mapper = mapper;

                _transactionRepository = transactionRepository;

                _response = response.Value;

                _billerRepository = billerRepository;

                _batchResponsitory = batchResponsitory;
            }
            public async Task<SuccessfulResponse> Handle(FlexSettlementCommand request, CancellationToken cancellationToken)
            {
                //automapper

                //checking for biller reference key

                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request.FlexSettlementDto.BillerId);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Wrong Biller Id", _response.NotFound, false, request.FlexSettlementDto);
                }

                Settlement addSettlement = await SaveSettlement(request, biller);

                var savedBatch = await SaveBatch(request, biller);

                await SaveTransaction(request, addSettlement, savedBatch);

                return ResponseGenerator.Response("Transaction Accepted", _response.OK, true);

            }

            public async Task<Batch> SaveBatch(FlexSettlementCommand request, Biller biller)
            {
                var batch = new Batch()
                {
                    TotalAmount = request.FlexSettlementDto.TotalAmount,

                    BillerId = biller.Id,

                    ItemCount = 1
                    
                };

                var savedBatch = await _batchResponsitory.Add(batch);

                return savedBatch;
            }

            private async Task<Settlement> SaveSettlement(FlexSettlementCommand request, Biller biller)
            {
                var settlement = new Settlement()
                {
                    Amount = request.FlexSettlementDto.TotalAmount,

                    BillerId = biller.Id,

                    PaidBy = request.FlexSettlementDto.PayerName,

                    PayerPhone = request.FlexSettlementDto.PayerPhone,

                    PaymentChannel = PaymentChannels.Card,

                    ReferenceID = request.FlexSettlementDto.ReferenceNumber,

                    TransactionNumber = request.FlexSettlementDto.TransactionNumber,

                    TransactionStatus = request.FlexSettlementDto.TransactionStatus,

                    TransactionType = TypesOfTransaction.SelfService,

                    StatusCode = request.FlexSettlementDto.StatusCode

                };

                var addSettlement = await _settlementRepository.Add(settlement);

                await _settlementRepository.CommitAsync();

                return addSettlement;
            }

            private async Task SaveTransaction(FlexSettlementCommand request, Settlement addSettlement, Batch batch)
            {
                foreach (var item in request.FlexSettlementDto.transactionItems)
                {
                    var transaction = new Transaction()
                    {
                        Amount = item.Amount,

                        BillerId = addSettlement.BillerId,

                        LevelOneId = item.LevelOneId,

                        LevelTwoId = item.LevelTwoId,

                        LevelThreeId = item.LevelThreeId,

                        PayerName = addSettlement.PaidBy,

                        PayerPhone = addSettlement.PayerPhone,

                        TransactionNumber = addSettlement.TransactionNumber,

                        PaymentChannel = addSettlement.PaymentChannel,

                        TransactionType = addSettlement.TransactionType,

                        StatusCode = addSettlement.StatusCode,

                        BatchId = batch.Id

                    };

                    await _transactionRepository.Add(transaction);
                }

                await _transactionRepository.CommitAsync();
            }
        }
    }
}
