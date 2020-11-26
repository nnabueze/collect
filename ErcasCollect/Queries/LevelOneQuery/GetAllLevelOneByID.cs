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
    public class GetAllLevelOneByIDQuery : IRequest<ReadLevelOneDto>
    {

        public string id { get; set; }
        public class GetAllLevelOneByIDHandler : IRequestHandler<GetAllLevelOneByIDQuery,ReadLevelOneDto>
        {
            private readonly IGenericRepository<LevelOne> leveloneRepository;
            private readonly IMapper mapper;

            public GetAllLevelOneByIDHandler(IGenericRepository<LevelOne> leveloneRepository, IMapper mapper)
            {
                this.leveloneRepository = leveloneRepository ?? throw new ArgumentNullException(nameof(leveloneRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<ReadLevelOneDto> Handle(GetAllLevelOneByIDQuery query, CancellationToken cancellationToken)
            {

                var result = await leveloneRepository.FindSingleInclude(x => x.Id == query.id, x => x.Biller, x => x.Status);
                if (result != null)
                {
                    var levelone = mapper.Map<ReadLevelOneDto>(result);
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

