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
    public class GetAllPOSQuery : IRequest<IEnumerable<ReadPosDto>>
    {


        public class GetAllPOSHandler : IRequestHandler<GetAllPOSQuery, IEnumerable<ReadPosDto>>
        {
            private readonly IGenericRepository<Pos> posRepository;
            private readonly IMapper mapper;

            public GetAllPOSHandler(IGenericRepository<Pos> posRepository, IMapper mapper)
            {
                this.posRepository = posRepository ?? throw new ArgumentNullException(nameof(posRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadPosDto>> Handle(GetAllPOSQuery query, CancellationToken cancellationToken)
            {

                var result = await posRepository.FindAllInclude(x => x.IsDeleted == false, x => x.Biller);
                if (result != null)
                {
                    var pos = mapper.Map<IEnumerable<ReadPosDto>>(result);
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

