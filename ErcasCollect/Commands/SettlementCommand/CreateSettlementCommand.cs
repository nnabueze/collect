using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.SettlementDto;

using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;

namespace ErcasCollect.Commands.SettlementCommand
{
    public class CreateSettlementCommand : IRequest<string>
    {
        public CreateSettlementDto createSettlementDto { get; set; }
        public class CreateSettlementCommandHandler : IRequestHandler<CreateSettlementCommand, string>
        {
            private readonly ISettlementRepository settlementRepository;
            private readonly IMapper mapper;
            private readonly ITransactionRepository transactionRepository;
            private readonly IUserRepository userRepository;
            public CreateSettlementCommandHandler(ISettlementRepository settlementRepository,IUserRepository userRepository,ITransactionRepository transactionRepository, IMapper mapper)
            {
                this.transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
                this.settlementRepository = settlementRepository ?? throw new ArgumentNullException(nameof(settlementRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            }

            public async Task<string> Handle(CreateSettlementCommand request, CancellationToken cancellationToken)
            {
                var transaction = mapper.Map<List<TransactionDetail>, List<Transaction>>(request.createSettlementDto.transactionDetail);

                List<Transaction> transactions = new List<Transaction>();

                //Create Settlement
       
                Settlement settlement = new Settlement();
                settlement.Id = Helpers.IdGenerator.IdGenerator.GetUniqueKey(10, 2);
                settlement.Amount = request.createSettlementDto.Amount;
                settlement.BankId= request.createSettlementDto.BankId;
                settlement.BillerId = request.createSettlementDto.BillerId;
                settlement.PaymentChannelId = request.createSettlementDto.PaymentChannelId;
                settlement.TransactionTypeId = request.createSettlementDto.TransactionTypeId;
                settlement.PaidBy = request.createSettlementDto.PaidBy;
                settlement.PayerPhone = request.createSettlementDto.PayerPhone;
                settlement.ReferenceID = request.createSettlementDto.ReferenceID;
                settlement.TransactionID = request.createSettlementDto.TransactionID;
                settlement.StatusId = request.createSettlementDto.StatusId;
                await  settlementRepository.Add(settlement);
                await  settlementRepository.CommitAsync();
                var gettransaction = await transactionRepository.GetSingle(x => x.Id == request.createSettlementDto.TransactionID);
                var getagent = await userRepository.GetSingle(x => x.Id == request.createSettlementDto.AgentId);
                if (gettransaction != null)
                {
                    if (request.createSettlementDto.StatusId == "200")
                    {

                        gettransaction.StatusId = "200";


                        transactionRepository.Update(gettransaction);
                       await transactionRepository.CommitAsync();


                        getagent.CashAtHand = 0;
                        getagent.StatusId = "300";
                        userRepository.Update(getagent);
                        await userRepository.CommitAsync();





                    }
                    else
                    {


                    }
                }
                else
                {
                    foreach (var transactionbatch in transaction)
                    {
                        transactionbatch.PayerPhone = request.createSettlementDto.PayerPhone;
                        transactionbatch.PaymentChannelId = request.createSettlementDto.PaymentChannelId;
                        transactionbatch.TransactionTypeId = request.createSettlementDto.TransactionTypeId;
                        transactionbatch.BillerId = request.createSettlementDto.BillerId;
                        transactionbatch.StatusId = request.createSettlementDto.StatusId;
                        transactionbatch.PayerName = request.createSettlementDto.PaidBy;
                        transactions.Add(transactionbatch);
                    }

                }


                await transactionRepository.Add(transactions);
                await transactionRepository.CommitAsync();
                return "Ok"; ;
                }
        }
    }
}
