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
    public class GetAllBanksQuery : IRequest<IEnumerable<ReadAllBanksDto>>
    {


        public class GetAllBanksHandler : IRequestHandler<GetAllBanksQuery, IEnumerable<ReadAllBanksDto>>
        {
            private readonly IGenericRepository<Bank> banksRepository;
            private readonly IMapper mapper;

            public GetAllBanksHandler(IGenericRepository<Bank> banksRepository, IMapper mapper)
            {
                this.banksRepository = banksRepository ?? throw new ArgumentNullException(nameof(banksRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadAllBanksDto>> Handle(GetAllBanksQuery query, CancellationToken cancellationToken)
            {

                var result = await banksRepository.GetAll();
                if (result != null)
                {
                    var biller = mapper.Map<IEnumerable<ReadAllBanksDto>>(result);
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

