using AutoMapper;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Collection
{
    public class MultiplePosCollectionCommand : IRequest<SuccessfulResponse>
    {
        public BatchPosCollectionDto BatchPosCollectionDto { get; set; }

        public class MultiplePosCollectionCommandHandler : IRequestHandler<MultiplePosCollectionCommand, SuccessfulResponse>
        {
            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<Transaction> _transactionRepository;

            private readonly IGenericRepository<Batch> _BatchRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<Pos> _posRespository;

            private readonly IGenericRepository<User> _userRepository;

            private readonly IMapper _mapper;

            private readonly IGenericRepository<CategoryTwoService> _categoryTwoServiceRepository;

            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<LevelTwo> _levelTwoRepository;

            private readonly IGenericRepository<CloseBatchTransaction> _closeBatchTransactionRepository;

            public MultiplePosCollectionCommandHandler(IOptions<ResponseCode> responseCode, IGenericRepository<Transaction> transactionRepository, IGenericRepository<Batch> batchRepository, 
                
                IGenericRepository<Biller> billerRepository, IGenericRepository<Pos> posRespository, IGenericRepository<User> userRepository, IMapper mapper, 
                
                IGenericRepository<CategoryTwoService> categoryTwoServiceRepository, IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<LevelTwo> levelTwoRepository, 
                
                IGenericRepository<CloseBatchTransaction> closeBatchTransactionRepository)
            {
                _responseCode = responseCode.Value;

                _transactionRepository = transactionRepository;

                _BatchRepository = batchRepository;

                _billerRepository = billerRepository;

                _posRespository = posRespository;

                _userRepository = userRepository;

                _mapper = mapper;

                _categoryTwoServiceRepository = categoryTwoServiceRepository;

                _levelOneRepository = levelOneRepository;

                _levelTwoRepository = levelTwoRepository;

                _closeBatchTransactionRepository = closeBatchTransactionRepository;
            }

            public Task<SuccessfulResponse> Handle(MultiplePosCollectionCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
