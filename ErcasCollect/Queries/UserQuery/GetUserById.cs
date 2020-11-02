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
    public class GetUserByIDQuery : IRequest<ReadUserDto>
    {
        public string id { get; set; }

        public class GetUserByIDHandler : IRequestHandler<GetUserByIDQuery, ReadUserDto>
        {
            private readonly IGenericRepository<User> taxpayerRepository;
            private readonly IMapper mapper;

            public GetUserByIDHandler(IGenericRepository<User> taxpayerRepository, IMapper mapper)
            {
                this.taxpayerRepository = taxpayerRepository ?? throw new ArgumentNullException(nameof(taxpayerRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<ReadUserDto> Handle(GetUserByIDQuery query, CancellationToken cancellationToken)
            {

                var result = await taxpayerRepository.FindSingleInclude(x => x.Id.Equals(query.id), x => x.Biller, x => x.Status);
                if (result != null)
                {
                    var biller = mapper.Map<ReadUserDto>(result);
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

