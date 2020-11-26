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
    public class GetAllStatesQuery : IRequest<IEnumerable<ReadAllStatesDto>>
    {


        public class GetAllStatesHandler : IRequestHandler<GetAllStatesQuery, IEnumerable<ReadAllStatesDto>>
        {
            private readonly IGenericRepository<State> stateRepository;
            private readonly IMapper mapper;

            public GetAllStatesHandler(IGenericRepository<State> stateRepository, IMapper mapper)
            {
                this.stateRepository = stateRepository ?? throw new ArgumentNullException(nameof(stateRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadAllStatesDto>> Handle(GetAllStatesQuery query, CancellationToken cancellationToken)
            {

                var result = await stateRepository.GetAll();
                if (result != null)
                {
                    var state= mapper.Map<IEnumerable<ReadAllStatesDto>>(result);
                    return state;
                }
                else
                {
                    return null;
                }

            }


        }
    }
}

