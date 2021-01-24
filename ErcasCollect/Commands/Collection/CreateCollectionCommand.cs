using AutoMapper;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Helpers.EnumClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.CollectionCommand
{
    public partial class CreateCollectionCommand : IRequest<int>
    {
        public SettlementCollectionComandDto collectionDto { get; set; }
        public class CreateCollectionCommandHandler : IRequestHandler<CreateCollectionCommand, int>
        {
            private readonly ITransactionRepository collectionRepository;
            private readonly IBatchRepository batchRepository;
            private readonly IBillerRepository billerRepository;
            private readonly IUserRepository userRepository;
        
            private readonly IMapper mapper;

            private readonly ResponseCode _responseCode;


            public CreateCollectionCommandHandler(ITransactionRepository collectionRepository,
                IBatchRepository batchRepository,
                IUserRepository userRepository, IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                this.collectionRepository = collectionRepository ?? throw new ArgumentNullException(nameof(collectionRepository));
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.batchRepository = batchRepository ?? throw new ArgumentNullException(nameof(batchRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _responseCode = responseCode.Value;
            }
            public async Task<int> Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
            {




                var collection = mapper.Map<List<SessionData>, List<Transaction>>(request.collectionDto.sessionData);

                List<Transaction> transactions = new List<Transaction>();

      

                var getuser = await userRepository.GetSingle(x => x.Id == request.collectionDto.AgentId);

                if ((getuser.CollectionLimit - getuser.CashAtHand) < request.collectionDto.Amount || getuser.StatusCode==_responseCode.RemmitanceGenerated )
                {
                    return 0; 

                }
                else
                {
                    if (request.collectionDto.TransactionTypeId == 1)
                    {


                    }
                    getuser.CashAtHand += request.collectionDto.Amount;
                    userRepository.Update(getuser);
                    Batch batch = new Batch();
                    batch.AgentId = request.collectionDto.AgentId;
                    batch.Id = request.collectionDto.BatchId;
                    batch.ItemCount = request.collectionDto.ItemCount;
                    batch.OfflineId = request.collectionDto.OfflineBatchId;
                    batch.Amount = request.collectionDto.Amount;
                  
                    await batchRepository.Add(batch);
                    await  batchRepository.CommitAsync();
                    
           
                    foreach (var collectionbatch in collection)
                    {
                        if (await collectionRepository.GetSingle(x => x.Id == collectionbatch.Id) == null)
                        {

                            collectionbatch.OfflineBatchId = request.collectionDto.OfflineBatchId;
                            collectionbatch.OfflineSessionId = request.collectionDto.OfflineSessionId;
                            collectionbatch.BatchId = request.collectionDto.BatchId;
                            collectionbatch.SessionId = request.collectionDto.SessionId;
                            collectionbatch.AgentId= request.collectionDto.AgentId;
                            collectionbatch.BillerId = request.collectionDto.BillerId;
                            collectionbatch.TransactionType = TypesOfTransaction.Collection;
                



                          

                            transactions.Add(collectionbatch);
                        }
                        else
                        {
                            var existingdata = await collectionRepository.GetSingle(x => x.Id == collectionbatch.Id);
                            if (existingdata != null)
                            {
                                var transaction = new Transaction();

                                transaction.IsDeleted = false;
                                transaction.BatchId = collectionbatch.BatchId;

                                collectionRepository.Update(transaction);
                            }
                        }
                    }
                    
                    await collectionRepository.Add(transactions);
                    await collectionRepository.CommitAsync();
                    return _responseCode.OK;
                }
            }
        }
    }
}