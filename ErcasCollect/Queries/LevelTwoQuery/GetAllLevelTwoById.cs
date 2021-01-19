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
    public class GetAllLevelTwoByBillerQuery : IRequest<IEnumerable<ReadLevelTwoDto>>
    {

        public int id { get; set; }
        public class GetAllLevelTwoByBillerHandler : IRequestHandler<GetAllLevelTwoByBillerQuery, IEnumerable<ReadLevelTwoDto>>
        {
            private readonly IGenericRepository<LevelTwo> leveltwoRepository;
            private readonly IMapper mapper;

            public GetAllLevelTwoByBillerHandler(IGenericRepository<LevelTwo> leveltwoRepository, IMapper mapper)
            {
                this.leveltwoRepository = leveltwoRepository ?? throw new ArgumentNullException(nameof(leveltwoRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadLevelTwoDto>> Handle(GetAllLevelTwoByBillerQuery query, CancellationToken cancellationToken)
            {

                var result = await leveltwoRepository.FindAllInclude(x => x.LevelOneId == query.id, x => x.Biller, x => x.StatusCode);
                if (result != null)
                {
                    var leveltwo = mapper.Map<IEnumerable<ReadLevelTwoDto>>(result);
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

