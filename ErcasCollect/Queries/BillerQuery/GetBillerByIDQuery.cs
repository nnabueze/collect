using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetBillerByIDQuery : IRequest<SuccessfulResponse>
    {
        public string id { get; set; }
    
        public class GetBillerByIDHandler : IRequestHandler<GetBillerByIDQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<Biller> billerRepository;

            private readonly IGenericRepository<State> stateRepository;

            private readonly IGenericRepository<BillerType> billerTypeRepository;

            private readonly IMapper mapper;

            private readonly ResponseCode _responseCode;

            public GetBillerByIDHandler(IGenericRepository<Biller> billerRepository, IMapper mapper, IGenericRepository<State> stateRepository,

                IGenericRepository<BillerType> billerTypeRepository, IOptions<ResponseCode> responseCode)
            {
                this.billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));

                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

                this.stateRepository = stateRepository;

                this.billerTypeRepository = billerTypeRepository;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(GetBillerByIDQuery query, CancellationToken cancellationToken)
            {

                var result = await billerRepository.FindSingleInclude(x => x.ReferenceKey.Equals(query.id));

                if (result == null)
                {
                    return ResponseGenerator.Response("Invalid billerId",_responseCode.NotFound, false);
                }

                var biller = mapper.Map<ReadBillerDto>(result);

                biller.State = stateRepository.FindFirst(x => x.Id == result.StateId).Name;

                biller.BillerType = billerTypeRepository.FindFirst(x => x.Id == result.Id).Category;

                return ResponseGenerator.Response("Successfull", _responseCode.OK, true, biller);
            }


        }
    }
}

