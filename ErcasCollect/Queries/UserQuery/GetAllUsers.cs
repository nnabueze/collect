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
    public class GetAllUsersQuery : IRequest<IEnumerable<ReadUserDto>>
    {


        public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<ReadUserDto>>
        {
            private readonly IGenericRepository<User> taxpayerRepository;
            private readonly IMapper mapper;

            public GetAllUsersHandler(IGenericRepository<User> taxpayerRepository, IMapper mapper)
            {
                this.taxpayerRepository = taxpayerRepository ?? throw new ArgumentNullException(nameof(taxpayerRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadUserDto>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {

                var result = await taxpayerRepository.FindAllInclude(x => x.IsDeleted == false, x => x.Biller, x => x.StatusCode);
                if (result != null)
                {
                    var taxpayer = mapper.Map<IEnumerable<ReadUserDto>>(result);
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

