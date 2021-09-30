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
    public class GetAllBillerByCategoryQuery : IRequest<SuccessfulResponse>
    {

        public int id { get; set; }
        public class GetAllBillerByCategoryHandler : IRequestHandler<GetAllBillerByCategoryQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<Biller> billerRepository;

            private readonly IMapper mapper;

            private readonly ResponseCode _responseCode;

            public GetAllBillerByCategoryHandler(IGenericRepository<Biller> billerRepository, IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                this.billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));

                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

                _responseCode = responseCode.Value;
            }            

            public async Task<SuccessfulResponse> Handle(GetAllBillerByCategoryQuery query, CancellationToken cancellationToken)
            {

                var result = await billerRepository.FindAllInclude(x => x.BillerTypeId == query.id);

                if (result == null)
                {
                    return ResponseGenerator.Response("Invalid billerTypeId", _responseCode.NotFound, false);
                }

                var biller = mapper.Map<IEnumerable<ReadBillerDto>>(result);

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, biller);

            }


        }
    }
}

