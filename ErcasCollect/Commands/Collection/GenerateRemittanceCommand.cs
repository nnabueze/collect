

using AutoMapper;
using ErcasCollect.Commands.Dto;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Helpers.EnumClasses;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
            private readonly ITransactionRepository _transactionRepository;

            private readonly IBatchRepository _batchRepository;

            private readonly IUserRepository _userRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;


            public GenerateRemittanceCommandHandler(ITransactionRepository transactionRepository,

                IBatchRepository batchRepository,

                IUserRepository userRepository, IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));

                _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

                _batchRepository = batchRepository ?? throw new ArgumentNullException(nameof(batchRepository));


                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

                _responseCode = responseCode.Value;
            }
            public async Task<RemiitanceResponse> Handle(GenerateRemittanceCommand request, CancellationToken cancellationToken)
            {

                var getuser = await _userRepository.GetSingle(x => x.Id == request.transactionDto.AgentId);


                if (request.transactionDto.ForceGenerate == false) { 

                    return new RemiitanceResponse { Message = "Remittance Checking",StatusCode = _responseCode.RemittanceChecking,Amount = getuser.CollectionLimit-getuser.CashAtHand};
                 } else{
                    Batch batch = new Batch();

                    batch.UserId = request.transactionDto.AgentId;
               
                    batch.ItemCount = 1;
                  
                    batch.TotalAmount = getuser.CashAtHand;

                    await _batchRepository.Add(batch);

                    await _batchRepository.CommitAsync();

                    Transaction transaction = new Transaction();

                    transaction.UserId = request.transactionDto.AgentId;

                    transaction.Amount = getuser.CashAtHand;

                    transaction.BillerId = getuser.BillerId;

                    transaction.LevelOneId = getuser.LevelOneId;

                    transaction.LevelTwoId = getuser.LevelTwoId;

                    transaction.PayerName = request.transactionDto.Name;

                    transaction.PayerPhone= request.transactionDto.PhoneNumber;

                    transaction.BatchId = batch.Id;

                    transaction.TransactionType = TypesOfTransaction.Remittance;

                    transaction.RemittanceNumber= Helpers.IdGenerator.IdGenerator.GetUniqueKey(10, 2);

                    transaction.PaymentChannel = PaymentChannels.POS;

                    await _transactionRepository.Add(transaction);

                    await _transactionRepository.CommitAsync();

                    getuser.StatusCode = _responseCode.RemmitanceGenerated;

                    _userRepository.Update(getuser);

                    await _userRepository.CommitAsync();


                    return new RemiitanceResponse { Message="Remittance Generated",StatusCode =_responseCode.RemmitanceGenerated,Amount=getuser.CashAtHand,RemittanceID =transaction.RemittanceNumber};
                }

                
            
            }
        }
    }
}