using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Queries.Dto;
using MediatR;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetAllTransactionTypesQuery : IRequest<IEnumerable<ReadAllTransactionTypes>>
    {


        public class GetAllTransactionTypesHandler : IRequestHandler<GetAllTransactionTypesQuery, IEnumerable<ReadAllTransactionTypes>>
        {
            private readonly IGenericRepository<TransactionType>transactiontypeRepository;
            private readonly IMapper mapper;

            public GetAllTransactionTypesHandler(IGenericRepository<TransactionType>transactiontypeRepository, IMapper mapper)
            {
                this.transactiontypeRepository = transactiontypeRepository ?? throw new ArgumentNullException(nameof(transactiontypeRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadAllTransactionTypes>> Handle(GetAllTransactionTypesQuery query, CancellationToken cancellationToken)
            {

                var result = await transactiontypeRepository.GetAll();
                if (result != null)
                {
                    var biller = mapper.Map<IEnumerable<ReadAllTransactionTypes>>(result);
                    return biller;
                }
                else
                {
                    return null;
                }

            }


        }
    }
}

