using System;
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
    public class GetTexPayerByIDQuery : IRequest<ReadTaxPayerDto>
    {
        public string id { get; set; }

        public class GetTexPayerByIDHandler : IRequestHandler<GetTexPayerByIDQuery, ReadTaxPayerDto>
        {
            private readonly IGenericRepository<TaxPayer> taxpayerRepository;
            private readonly IMapper mapper;

            public GetTexPayerByIDHandler(IGenericRepository<TaxPayer> taxpayerRepository, IMapper mapper)
            {
                this.taxpayerRepository = taxpayerRepository ?? throw new ArgumentNullException(nameof(taxpayerRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<ReadTaxPayerDto> Handle(GetTexPayerByIDQuery query, CancellationToken cancellationToken)
            {

                var result = await taxpayerRepository.FindSingleInclude(x => x.Id.Equals(query.id), x => x.Biller, x => x.StatusCode);
                if (result != null)
                {
                    var biller = mapper.Map<ReadTaxPayerDto>(result);
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

