using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Queries.Dto;
using ErcasCollect.Queries.Dto.ReadTransactionDto;
using MediatR;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetTransactionForAdminQuery : IRequest<IEnumerable<ReadTransactionDto>>
    {

  
        public class GetTransactionForAdminHandler : IRequestHandler<GetTransactionForAdminQuery, IEnumerable<ReadTransactionDto>>
        {
            private readonly IGenericRepository<Transaction> transactionbybatchidRepository;
            private readonly IMapper mapper;

            public GetTransactionForAdminHandler(IGenericRepository<Transaction> transactionbybatchidRepository, IMapper mapper)
            {
                this.transactionbybatchidRepository = transactionbybatchidRepository ?? throw new ArgumentNullException(nameof(transactionbybatchidRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadTransactionDto>> Handle(GetTransactionForAdminQuery query, CancellationToken cancellationToken)
            {

                var result = await transactionbybatchidRepository.AllIncluding(x => x.Status, x => x.Agent, x => x.Biller, x => x.PaymentChannel, x => x.TransactionType);
                if (result != null)
                {
                    var transactionbybatchid = mapper.Map<IEnumerable<ReadTransactionDto>>(result);
                    return transactionbybatchid;
                }
                else
                {
                    return null;
                }

            }


        }
    }
}

