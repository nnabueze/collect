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
    public class GetAllLevelOneByBillerQuery : IRequest<IEnumerable<ReadLevelOneDto>>
    {

        public string id { get; set; }
        public class GetAllLevelOneByBillerHandler : IRequestHandler<GetAllLevelOneByBillerQuery, IEnumerable<ReadLevelOneDto>>
        {
            private readonly IGenericRepository<LevelOne> leveloneRepository;
            private readonly IMapper mapper;

            public GetAllLevelOneByBillerHandler(IGenericRepository<LevelOne> leveloneRepository, IMapper mapper)
            {
                this.leveloneRepository= leveloneRepository ?? throw new ArgumentNullException(nameof(leveloneRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadLevelOneDto>> Handle(GetAllLevelOneByBillerQuery query, CancellationToken cancellationToken)
            {

                var result = await leveloneRepository.FindAllInclude(x => x.BillerId==query.id, x => x.Biller,x=>x.Status);
                if (result != null)
                {
                    var levelone = mapper.Map<IEnumerable<ReadLevelOneDto>>(result);
                    return levelone;
                }
                else
                {
                    return null;
                }

            }


        }
    }
}

