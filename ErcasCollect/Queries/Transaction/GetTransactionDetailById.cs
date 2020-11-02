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
    public class GetTransactionDetailByIDQuery : IRequest<ReadTransactionDto>
    {

        public string id { get; set; }
        public class GetTransactionDetailByIDHandler : IRequestHandler<GetTransactionDetailByIDQuery,ReadTransactionDto>
        {
            private readonly IGenericRepository<Transaction> transactionbybatchidRepository;
            private readonly IMapper mapper;

            public GetTransactionDetailByIDHandler(IGenericRepository<Transaction> transactionbybatchidRepository, IMapper mapper)
            {
                this.transactionbybatchidRepository = transactionbybatchidRepository ?? throw new ArgumentNullException(nameof(transactionbybatchidRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<ReadTransactionDto> Handle(GetTransactionDetailByIDQuery query, CancellationToken cancellationToken)
            {

                var result = await transactionbybatchidRepository.FindAllInclude(x => x.Id == query.id, x => x.Status, x => x.Agent, x => x.Biller, x => x.PaymentChannel, x => x.TransactionType);
                if (result != null)
                {
                    var transactionbybatchid = mapper.Map<ReadTransactionDto>(result);
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

