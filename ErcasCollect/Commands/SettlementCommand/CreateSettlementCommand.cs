using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.SettlementDto;

using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Helpers.EnumClasses;
using MediatR;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Commands.SettlementCommand
{
    public class CreateSettlementCommand : IRequest<string>
    {
        //public CreateSettlementDto createSettlementDto { get; set; }
        //public class CreateSettlementCommandHandler : IRequestHandler<CreateSettlementCommand, string>
        //{
        //    private readonly ISettlementRepository settlementRepository;
        //    private readonly IMapper mapper;
        //    private readonly ITransactionRepository transactionRepository;
        //    private readonly IUserRepository userRepository;
        //    private readonly ResponseCode _response;
        //    public CreateSettlementCommandHandler(ISettlementRepository settlementRepository, IUserRepository userRepository, ITransactionRepository transactionRepository,
                
        //        IMapper mapper, IOptions<ResponseCode> response)
        //    {
        //        this.transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        //        this.settlementRepository = settlementRepository ?? throw new ArgumentNullException(nameof(settlementRepository));
        //        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        //        this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        //        _response = response.Value;
        //    }

        //    public async Task<string> Handle(CreateSettlementCommand request, CancellationToken cancellationToken)
        //    {
        //        var transaction = mapper.Map<List<TransactionDetail>, List<Transaction>>(request.createSettlementDto.transactionDetail);

        //        List<Transaction> transactions = new List<Transaction>();

        //        //Create Settlement
       
        //        Settlement settlement = new Settlement();
        //        settlement.Amount = request.createSettlementDto.Amount;
        //        settlement.Bank= request.createSettlementDto.Bank;
        //        settlement.BillerId = request.createSettlementDto.BillerId;
        //        settlement.PaymentChannel = PaymentChannels.Nibss;
        //        settlement.TransactionType = TypesOfTransaction.NonTax;
        //        settlement.PaidBy = request.createSettlementDto.PaidBy;
        //        settlement.PayerPhone = request.createSettlementDto.PayerPhone;
        //        settlement.ReferenceID = request.createSettlementDto.ReferenceID;
        //        settlement.TransactionNumber = request.createSettlementDto.TransactionNumber;
        //        settlement.StatusCode = request.createSettlementDto.StatusCode;
        //        await  settlementRepository.Add(settlement);
        //        await  settlementRepository.CommitAsync();
        //        var gettransaction = await transactionRepository.GetSingle(x => x.TransactionNumber == request.createSettlementDto.TransactionNumber);
        //        var getagent = await userRepository.GetSingle(x => x.Id == request.createSettlementDto.AgentId);
        //        if (gettransaction != null)
        //        {
        //            if (request.createSettlementDto.StatusCode == _response.OK)
        //            {

        //                gettransaction.StatusCode = _response.OK;


        //                transactionRepository.Update(gettransaction);
        //               await transactionRepository.CommitAsync();


        //                getagent.CashAtHand = 0;
        //                getagent.StatusCode = _response.AccountActivated;
        //                userRepository.Update(getagent);
        //                await userRepository.CommitAsync();





        //            }
        //            else
        //            {


        //            }
        //        }
        //        else
        //        {
        //            foreach (var transactionbatch in transaction)
        //            {
        //                transactionbatch.PayerPhone = request.createSettlementDto.PayerPhone;
        //                transactionbatch.PaymentChannel = PaymentChannels.Nibss;
        //                transactionbatch.TransactionType = TypesOfTransaction.NonTax;
        //                transactionbatch.BillerId = request.createSettlementDto.BillerId;
        //                transactionbatch.StatusCode = request.createSettlementDto.StatusCode;
        //                transactionbatch.PayerName = request.createSettlementDto.PaidBy;
        //                transactions.Add(transactionbatch);
        //            }

        //        }


        //        await transactionRepository.Add(transactions);
        //        await transactionRepository.CommitAsync();
        //        return "Ok"; ;
        //        }
        //}
    }
}
