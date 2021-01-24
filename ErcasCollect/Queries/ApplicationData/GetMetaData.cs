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
    public class GetAllMetaDataQuery : IRequest<ReadAllMetaDataDto>
    {

        public int id { get; set; }
        public class GetAllMetaDataHandler : IRequestHandler<GetAllMetaDataQuery,ReadAllMetaDataDto>
        {
            private readonly IGenericRepository<MetaData> metaDataRepository;
            private readonly IGenericRepository<Biller> billerDataRepository;
            private readonly IMapper mapper;

            public GetAllMetaDataHandler(IGenericRepository<MetaData> metaDataRepository, IGenericRepository<Biller> billerDataRepository, IMapper mapper)
            {
                this.metaDataRepository = metaDataRepository ?? throw new ArgumentNullException(nameof(metaDataRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                this.billerDataRepository = billerDataRepository ?? throw new ArgumentNullException(nameof(billerDataRepository));

            }

            public async Task<ReadAllMetaDataDto> Handle(GetAllMetaDataQuery query, CancellationToken cancellationToken)
            {

                var user = await billerDataRepository.GetSingle(x => x.Id == query.id);

                //var result = await metaDataRepository.GetSingle(x => x.BillerTypeId == user.BillerTypeId);
                //if (result != null)
                //{
                //    var biller = mapper.Map<ReadAllMetaDataDto>(result);
                //    return biller;
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

