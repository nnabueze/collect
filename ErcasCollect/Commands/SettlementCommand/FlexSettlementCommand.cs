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

            private readonly IMapper _mapper;

            private readonly ResponseCode _response;

            public FlexSettlementCommandHandler(ISettlementRepository settlementRepository, IGenericRepository<Biller> billerRepository, 
                
                IGenericRepository<CloseBatchTransaction> closeBatchTransactionResponsitory, IMapper mapper, IOptions<ResponseCode> response)
            {
                _settlementRepository = settlementRepository;

                _billerRepository = billerRepository;

                _closeBatchTransactionResponsitory = closeBatchTransactionResponsitory;

                _mapper = mapper;

                _response = response.Value;
            }

            public async Task<SuccessfulResponse> Handle(FlexSettlementCommand request, CancellationToken cancellationToken)
            {
                //automapper
                Biller biller = GetBiller(request);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Wrong Biller Id", _response.NotFound, false, request.FlexSettlementDto);
                }

                await SaveSettlement(request, biller);

                if (request.FlexSettlementDto.IsSuccess)
                {
                    await SaveCloseBatchTransaction(request, biller);
                }

                return ResponseGenerator.Response("Transaction Accepted", _response.OK, true);

            }

            private async Task SaveCloseBatchTransaction(FlexSettlementCommand request, Biller biller)
            {
                var saveCloseTransaction = new CloseBatchTransaction()
                {
                     BillerId = biller.Id,

                     IsPaid = true,

                     PaymentChannel = PaymentChannels.Card,

                     ReferenceKey = request.FlexSettlementDto.TransactionNumber,

                     TotalAmount = Convert.ToDecimal(request.FlexSettlementDto.TotalAmount)                     
                };

                await _closeBatchTransactionResponsitory.Add(saveCloseTransaction);

                await _closeBatchTransactionResponsitory.CommitAsync();
            }

            private Biller GetBiller(FlexSettlementCommand request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request.FlexSettlementDto.BillerId);
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

                    TransactionType = TypesOfTransaction.SelfService,

                    IsSuccess = request.FlexSettlementDto.IsSuccess

                };

                var addSettlement = await _settlementRepository.Add(settlement);

                await _settlementRepository.CommitAsync();

                return addSettlement;
            }
        }
    }
}
