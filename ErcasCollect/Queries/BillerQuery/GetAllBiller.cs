using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetAllBillerQuery : IRequest<IEnumerable<ReadBillerDto>>
    {


        public class GetAllBillerHandler : IRequestHandler<GetAllBillerQuery, IEnumerable<ReadBillerDto>>
        {
            private readonly IGenericRepository<Biller> billerRepository;
            private readonly IMapper mapper;

            public GetAllBillerHandler(IGenericRepository<Biller> billerRepository, IMapper mapper)
            {
                this.billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadBillerDto>> Handle(GetAllBillerQuery query, CancellationToken cancellationToken)
            {

                var result = await billerRepository.FindAllInclude(x=>x.IsDeleted==false,x=>x.State,x=>x.BillerType,x=>x.StatusCode);
                if (result != null)
                {
                    var biller = mapper.Map<IEnumerable<ReadBillerDto>>(result);
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

