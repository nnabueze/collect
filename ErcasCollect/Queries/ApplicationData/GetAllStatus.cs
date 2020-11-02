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
    public class GetAllStatusQuery : IRequest<IEnumerable<ReadStatusDto>>
    {


        public class GetAllStatusHandler : IRequestHandler<GetAllStatusQuery, IEnumerable<ReadStatusDto>>
        {
            private readonly IGenericRepository<Status> statusRepository;
            private readonly IMapper mapper;

            public GetAllStatusHandler(IGenericRepository<Status> statusRepository, IMapper mapper)
            {
                this.statusRepository = statusRepository ?? throw new ArgumentNullException(nameof(statusRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadStatusDto>> Handle(GetAllStatusQuery query, CancellationToken cancellationToken)
            {

                var result = await statusRepository.GetAll();
                if (result != null)
                {
                    var biller = mapper.Map<IEnumerable<ReadStatusDto>>(result);
                    return biller;
                }
                else
                {
                    return null;
                }

            }


        }
    }
}

