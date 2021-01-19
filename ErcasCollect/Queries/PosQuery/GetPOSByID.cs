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
    public class GetPOSByIDQuery : IRequest<ReadPosDto>
    {

        public int id { get; set; }
        public class GetPOSByIDHandler : IRequestHandler<GetPOSByIDQuery, ReadPosDto>
        {
            private readonly IGenericRepository<Pos> posRepository;
            private readonly IMapper mapper;

            public GetPOSByIDHandler(IGenericRepository<Pos> posRepository, IMapper mapper)
            {
                this.posRepository = posRepository ?? throw new ArgumentNullException(nameof(posRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<ReadPosDto> Handle(GetPOSByIDQuery query, CancellationToken cancellationToken)
            {

                var result = await posRepository.FindSingleInclude(x => x.Id == query.id, x => x.Biller, x => x.StatusCode, x => x.OS);
                if (result != null)
                {
                    var pos = mapper.Map<ReadPosDto>(result);
                    return pos;
                }
                else
                {
                    return null;
                }

            }


        }
    }
}

