using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetAllErcasEbillsProductQuery : IRequest<SuccessfulResponse>
    {
        public class GetAllErcasEbillsProductQueryHandler : IRequestHandler<GetAllErcasEbillsProductQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<EbillsProduct> _ebillsProductRepository;

            private readonly ResponseCode _responseCode;

            private readonly IMapper _mapper;

            public GetAllErcasEbillsProductQueryHandler(IGenericRepository<EbillsProduct> ebillsProductRepository, IOptions<ResponseCode> responseCode, IMapper mapper)
            {
                _ebillsProductRepository = ebillsProductRepository;

                _responseCode = responseCode.Value;

                _mapper = mapper;
            }

            public async Task<SuccessfulResponse> Handle(GetAllErcasEbillsProductQuery request, CancellationToken cancellationToken)
            {
                var ebillsProduct =  _ebillsProductRepository.FindAllEnumerable().Select(_mapper.Map<EbillsProduct, EbillsProductResponseDto>);

                return ResponseGenerator.Response("Seccessful", _responseCode.OK, true, ebillsProduct);
            }
        }
    }
}
