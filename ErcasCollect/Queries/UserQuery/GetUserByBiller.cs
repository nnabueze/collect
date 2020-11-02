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
    public class GetAllUserByBillerQuery : IRequest<IEnumerable<ReadUserDto>>
    {

        public string id { get; set; }
        public class GetAllUserByBillerHandler : IRequestHandler<GetAllUserByBillerQuery, IEnumerable<ReadUserDto>>
        {
            private readonly IGenericRepository<User> userRepository;
            private readonly IMapper mapper;

            public GetAllUserByBillerHandler(IGenericRepository<User> userRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadUserDto>> Handle(GetAllUserByBillerQuery query, CancellationToken cancellationToken)
            {

                var result = await userRepository.FindAllInclude(x => x.BillerId == query.id, x => x.Biller, x => x.Status, x => x.LevelOne, x => x.LevelTwo );
                if (result != null)
                {
                    var user  = mapper.Map<IEnumerable<ReadUserDto>>(result);
                    return user;
                }
                else
                {
                    return null;
                }

            }


        }
    }
}

