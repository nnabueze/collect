using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Queries.Dto;
using MediatR;

namespace ErcasCollect.Queries.osQuery
{
    public class GetOsQuery : IRequest<IEnumerable<ReadAllOs>>
    {


        public class GetOsHandler : IRequestHandler<GetOsQuery, IEnumerable<ReadAllOs>>
        {
            private readonly IGenericRepository<OS> osRepository;
            private readonly IMapper mapper;

            public GetOsHandler(IGenericRepository<OS> osRepository, IMapper mapper)
            {
                this.osRepository = osRepository ?? throw new ArgumentNullException(nameof(osRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadAllOs>> Handle(GetOsQuery query, CancellationToken cancellationToken)
            {

                var result = await osRepository.GetAll();
                if (result != null)
                {
                    var os = mapper.Map<IEnumerable<ReadAllOs>>(result);
                    return os;
                }
                else
                {
                    return null;
                }

            }


        }
    }
}

