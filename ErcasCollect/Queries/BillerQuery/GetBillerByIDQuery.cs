using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetBillerByIDQuery : IRequest<ReadBillerDto>
    {
        public string id { get; set; }
    
        public class GetBillerByIDHandler : IRequestHandler<GetBillerByIDQuery, ReadBillerDto>
        {
            private readonly IGenericRepository<Biller> billerRepository;
            private readonly IMapper mapper;

            public GetBillerByIDHandler(IGenericRepository<Biller> billerRepository,IMapper mapper)
            {
                this.billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<ReadBillerDto> Handle(GetBillerByIDQuery query, CancellationToken cancellationToken)
            {

                var result = await billerRepository.FindSingleInclude(x => x.Id.Equals(query.id),x => x.State, x => x.BillerType);
                if (result != null)
                {
                    var biller = mapper.Map<ReadBillerDto>(result);
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

