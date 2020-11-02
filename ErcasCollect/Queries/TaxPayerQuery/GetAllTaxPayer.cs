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
    public class GetAllTaxPayerQuery : IRequest<IEnumerable<ReadTaxPayerDto>>
    {


        public class GetAllTaxPayerHandler : IRequestHandler<GetAllTaxPayerQuery, IEnumerable<ReadTaxPayerDto>>
        {
            private readonly IGenericRepository<TaxPayer> taxpayerRepository;
            private readonly IMapper mapper;

            public GetAllTaxPayerHandler(IGenericRepository<TaxPayer> taxpayerRepository, IMapper mapper)
            {
                this.taxpayerRepository = taxpayerRepository ?? throw new ArgumentNullException(nameof(taxpayerRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadTaxPayerDto>> Handle(GetAllTaxPayerQuery query, CancellationToken cancellationToken)
            {

                var result = await taxpayerRepository.FindAllInclude(x => x.IsDeleted == false, x => x.Biller, x => x.Status);
                if (result != null)
                {
                    var taxpayer = mapper.Map<IEnumerable<ReadTaxPayerDto>>(result);
                    return taxpayer;
                }
                else
                {
                    return null;
                }

            }


        }
    }
}

