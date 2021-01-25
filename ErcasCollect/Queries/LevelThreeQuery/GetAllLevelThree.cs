using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Queries.Dto;
using MediatR;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetAllLevelThreeByBillerQuery : IRequest<IEnumerable<ReadLevelThreeDto>>
    {

        public int id { get; set; }
        public class GetAllLevelThreeByBillerHandler : IRequestHandler<GetAllLevelThreeByBillerQuery, IEnumerable<ReadLevelThreeDto>>
        {
            private readonly IGenericRepository<LevelThree> levelthreeRepository;
            private readonly IMapper mapper;

            public GetAllLevelThreeByBillerHandler(IGenericRepository<LevelThree> levelthreeRepository, IMapper mapper)
            {
                this.levelthreeRepository = levelthreeRepository ?? throw new ArgumentNullException(nameof(levelthreeRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadLevelThreeDto>> Handle(GetAllLevelThreeByBillerQuery query, CancellationToken cancellationToken)
            {

                //var result = await levelthreeRepository.FindAllInclude(x => x.LevelTwoId == query.id, x => x.Biller);
                //if (result != null)
                //{
                //    var levelone = mapper.Map<IEnumerable<ReadLevelThreeDto>>(result);
                //    return levelone;
                //}
                //else
                //{
                //    return null;
                //}

                return null;

            }


        }
    }
}

