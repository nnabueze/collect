using AutoMapper;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.CollectionCommand
{
    public partial class CreateCollectionCommand : IRequest<string>
    {
        public CreateCollectionComandDto collectionDto { get; set; }
        public class CreateCollectionCommandHandler : IRequestHandler<CreateCollectionCommand, string>
        {
            private readonly ITransactionRepository collectionRepository;
            private readonly IBatchRepository batchRepository;
            private readonly IMapper mapper;

            public CreateCollectionCommandHandler(ITransactionRepository collectionRepository, IMapper mapper)
            {
                this.collectionRepository = collectionRepository ?? throw new ArgumentNullException(nameof(collectionRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }
            public async Task<string> Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
            {
                var collection = mapper.Map<List<SessionData>, List<Transaction>>(request.collectionDto.sessionData);

                List<Transaction> transactions = new List<Transaction>();

                foreach (var collectionbatch in collection)
                {
                    if (await collectionRepository.GetSingle(x => x.Id == collectionbatch.Id) == null)
                    {

                        collectionbatch.OfflineBatchId = request.collectionDto.OfflineBatchId;
                        collectionbatch.OfflineSessionId = request.collectionDto.OfflineSessionId;
                        collectionbatch.BatchId = request.collectionDto.BatchId;
                        collectionbatch.SessionId = request.collectionDto.SessionId;

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
                return "Ok";

            }
        }
    }
}