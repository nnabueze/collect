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
    public class GetAllRolesQuery : IRequest<IEnumerable<ReadAllRolesDto>>
    {


        public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<ReadAllRolesDto>>
        {
            private readonly IGenericRepository<Role> banksRepository;
            private readonly IMapper mapper;

            public GetAllRolesHandler(IGenericRepository<Role> banksRepository, IMapper mapper)
            {
                this.banksRepository = banksRepository ?? throw new ArgumentNullException(nameof(banksRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadAllRolesDto>> Handle(GetAllRolesQuery query, CancellationToken cancellationToken)
            {

                var result = await banksRepository.GetAll();
                if (result != null)
                {
                    var biller = mapper.Map<IEnumerable<ReadAllRolesDto>>(result);
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

