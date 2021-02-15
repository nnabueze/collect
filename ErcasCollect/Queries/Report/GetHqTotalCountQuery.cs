using AutoMapper;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models.SqlViewModels;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Queries.Report
{
    public class GetHqTotalCountQuery : IRequest<SuccessfulResponse>
    {
        public class GetHqTotalCountQueryHandler : IRequestHandler<GetHqTotalCountQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<HqAllBillersYearlyTotalAmount> _hqAllBillerYearlyTotalRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public GetHqTotalCountQueryHandler(IGenericRepository<HqAllBillersYearlyTotalAmount> hqAllBillerYearlyTotalRepository, IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _hqAllBillerYearlyTotalRepository = hqAllBillerYearlyTotalRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(GetHqTotalCountQuery request, CancellationToken cancellationToken)
            {
                var yearlyTotalCount =  _hqAllBillerYearlyTotalRepository.FirstOrDefault();

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, new { TotalAmount = yearlyTotalCount });
            }
        }
    }
}
