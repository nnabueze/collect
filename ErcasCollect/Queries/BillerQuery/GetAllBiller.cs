using System;
using System.Collections.Generic;
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
    public class GetAllBillerQuery : IRequest<SuccessfulResponse>
    {


        public class GetAllBillerHandler : IRequestHandler<GetAllBillerQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<Biller> billerRepository;

            private readonly IGenericRepository<BillerType> billerTypeRepository;

            private readonly IGenericRepository<State> stateRepository;

            private readonly IMapper mapper;

            private readonly ResponseCode _responseCode;

            public GetAllBillerHandler(IGenericRepository<Biller> billerRepository, IMapper mapper, IOptions<ResponseCode> responseCode,

                IGenericRepository<BillerType> billerTypeRepository, IGenericRepository<State> stateRepository)
            {
                this.billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));

                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

                _responseCode = responseCode.Value;

                this.billerTypeRepository = billerTypeRepository;

                this.stateRepository = stateRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetAllBillerQuery query, CancellationToken cancellationToken)
            {
                List<ReadBillerDto> listBiller = new List<ReadBillerDto>();

                var billers = mapper.Map<IEnumerable<ReadBillerDto>>(await billerRepository.FindAllInclude(x => x.IsDeleted == false));

                foreach (var item in billers)
                {
                    item.BillerType = billerTypeRepository.FindFirst(x => x.Id == item.BillerTypeId).Category;

                    item.State = stateRepository.FindFirst(x => x.Id == item.StateId).Name;

                    listBiller.Add(item);
                }

                return new SuccessfulResponse()
                {
                    Message = "Successful",

                    StatusCode = _responseCode.OK,

                    IsSuccess = true,

                    Data = new
                    {
                        Billers = listBiller
                    }
                };

            }


        }
    }
}

