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
    public class GetAllBillerTypesQuery : IRequest<IEnumerable<ReadAllBillerTypesDto>>
    {


        public class GetAllBillerTypesHandler : IRequestHandler<GetAllBillerTypesQuery, IEnumerable<ReadAllBillerTypesDto>>
        {
            private readonly IGenericRepository<BillerType> billertypesRepository;
            private readonly IMapper mapper;

            public GetAllBillerTypesHandler(IGenericRepository<BillerType> billertypesRepository, IMapper mapper)
            {
                this.billertypesRepository = billertypesRepository ?? throw new ArgumentNullException(nameof(billertypesRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadAllBillerTypesDto>> Handle(GetAllBillerTypesQuery query, CancellationToken cancellationToken)
            {

                var result = await billertypesRepository.GetAll();
                if (result != null)
                {
                    var biller = mapper.Map<IEnumerable<ReadAllBillerTypesDto>>(result);
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

