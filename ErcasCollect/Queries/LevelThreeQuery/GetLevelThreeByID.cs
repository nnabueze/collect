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
    public class GetAllLevelThreeByIDQuery : IRequest<ReadLevelThreeDto>
    {

        //public int id { get; set; }
        //public class GetAllLevelThreeByIDHandler : IRequestHandler<GetAllLevelThreeByIDQuery, ReadLevelThreeDto>
        //{
        //    private readonly IGenericRepository<LevelThree> levelthreeRepository;
        //    private readonly IMapper mapper;

        //    public GetAllLevelThreeByIDHandler(IGenericRepository<LevelThree> levelthreeRepository, IMapper mapper)
        //    {
        //        this.levelthreeRepository = levelthreeRepository ?? throw new ArgumentNullException(nameof(levelthreeRepository));
        //        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        //    }

        //    public async Task<ReadLevelThreeDto> Handle(GetAllLevelThreeByIDQuery query, CancellationToken cancellationToken)
        //    {

        //        var result = await levelthreeRepository.FindSingleInclude(x => x.Id == query.id, x => x.Biller);
        //        if (result != null)
        //        {
        //            var levelone = mapper.Map<ReadLevelThreeDto>(result);
        //            return levelone;
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //    }


        //}
    }
}

