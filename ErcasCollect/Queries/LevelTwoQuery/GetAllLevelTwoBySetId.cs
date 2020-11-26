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
    public class GetAllLevelTwoByIdQuery : IRequest<ReadLevelTwoDto>
    {

        public string id { get; set; }
        public class GetAllLevelTwoByIdHandler : IRequestHandler<GetAllLevelTwoByIdQuery, ReadLevelTwoDto>
        {
            private readonly IGenericRepository<LevelTwo> leveltwoRepository;
            private readonly IMapper mapper;

            public GetAllLevelTwoByIdHandler(IGenericRepository<LevelTwo> leveltwoRepository, IMapper mapper)
            {
                this.leveltwoRepository = leveltwoRepository ?? throw new ArgumentNullException(nameof(leveltwoRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<ReadLevelTwoDto> Handle(GetAllLevelTwoByIdQuery query, CancellationToken cancellationToken)
            {

                var result = await leveltwoRepository.FindSingleInclude(x => x.Id == query.id, x => x.Biller, x => x.Status);
                if (result != null)
                {
                    var leveltwo = mapper.Map<ReadLevelTwoDto>(result);
                    return leveltwo;
                }
                else
                {
                    return null;
                }

            }


        }
    }
}

