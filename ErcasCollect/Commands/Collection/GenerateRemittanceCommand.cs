

using AutoMapper;
using ErcasCollect.Commands.Dto;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.CollectionCommand
{
    public partial class GenerateRemittanceCommand : IRequest<RemiitanceResponse>
    {
        public GenerateRemittanceDto transactionDto { get; set; }
        public class GenerateRemittanceCommandHandler : IRequestHandler<GenerateRemittanceCommand, RemiitanceResponse>
        {
            private readonly ITransactionRepository transactionRepository;
            private readonly IBatchRepository batchRepository;
            private readonly IUserRepository userRepository;

            private readonly IMapper mapper;


            public GenerateRemittanceCommandHandler(ITransactionRepository transactionRepository,
                IBatchRepository batchRepository,
                IUserRepository userRepository, IMapper mapper)
            {
                this.transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.batchRepository = batchRepository ?? throw new ArgumentNullException(nameof(batchRepository));

                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }
            public async Task<RemiitanceResponse> Handle(GenerateRemittanceCommand request, CancellationToken cancellationToken)
            {

                var getuser = await userRepository.GetSingle(x => x.Id == request.transactionDto.AgentId);


                if (request.transactionDto.ForceGenerate == false) { 

                    return new RemiitanceResponse { Message = "Remittance Checking",StatusCode = "N/A",Amount = getuser.CollectionLimit-getuser.CashAtHand};
                 } else{
                    Batch batch = new Batch();
                    batch.AgentId = request.transactionDto.AgentId;
               
                    batch.ItemCount = 1;
                  
                    batch.Amount = getuser.CashAtHand;

                    await batchRepository.Add(batch);
                    await batchRepository.CommitAsync();

                    Transaction transaction = new Transaction();
                    transaction.AgentId = request.transactionDto.AgentId;
                    transaction.Amount = getuser.CashAtHand;
                    transaction.BillerId = getuser.BillerId;
                    transaction.LevelOneId = getuser.LevelOneId;
                    transaction.LevelTwoId = getuser.LevelTwoId;
                    transaction.PayerName = request.transactionDto.Name;
                    transaction.PayerPhone= request.transactionDto.PhoneNumber;
                    transaction.BatchId = batch.Id;
                    transaction.TransactionTypeId = 2;
                    transaction.Id= Helpers.IdGenerator.IdGenerator.GetUniqueKey(10, 2);
                    transaction.PaymentChannelId = 1;
                    await transactionRepository.Add(transaction);
                    await transactionRepository.CommitAsync();

                    getuser.StatusId = "350";
                    userRepository.Update(getuser);
                    await userRepository.CommitAsync();


                    return new RemiitanceResponse { Message="Remittance Generated",StatusCode="350",Amount=getuser.CashAtHand,RemittanceID =transaction.Id};
                }

                
            
            }
        }
    }
}