using AutoMapper;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models.SqlViewModels;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.Dto;
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
    public class MonthlyTopPerformingBillersQuery : IRequest<SuccessfulResponse>
    {
        public class MonthlyTopPerformingBillersQueryHandler : IRequestHandler<MonthlyTopPerformingBillersQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<MonthlyTopPerformingBillers> _monthlyTopPerformingBillers;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public MonthlyTopPerformingBillersQueryHandler(IGenericRepository<MonthlyTopPerformingBillers> monthlyTopPerformingBillers, 
                
                IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _monthlyTopPerformingBillers = monthlyTopPerformingBillers;

                _mapper = mapper;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(MonthlyTopPerformingBillersQuery request, CancellationToken cancellationToken)
            {
                var report = _monthlyTopPerformingBillers.FindAllEnumerable().Select(_mapper.Map<MonthlyTopPerformingBillers, MonthlyTopPerformingBillerDto>);

                return ResponseGenerator.Response("Success", _responseCode.OK, true, report);
            }
        }
    }
}
