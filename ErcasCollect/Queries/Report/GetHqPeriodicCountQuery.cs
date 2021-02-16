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
    public class GetHqPeriodicCountQuery : IRequest<SuccessfulResponse>
    {
        public class GetHqPeriodicCountQueryHandler : IRequestHandler<GetHqPeriodicCountQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<HqYestardayTotalAmount> _hqYestardayTotalAmountRepository;

            private readonly IGenericRepository<HqDaylyTotalAmount> _hqDaylyTotalAmountRepository;

            private readonly IGenericRepository<HqWeeklyTotalAmount> _hqWeeklyTotalAmountRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public GetHqPeriodicCountQueryHandler(IGenericRepository<HqYestardayTotalAmount> hqYestardayTotalAmountRepository, IGenericRepository<HqDaylyTotalAmount> hqDaylyTotalAmountRepository, 
                
                IGenericRepository<HqWeeklyTotalAmount> hqWeeklyTotalAmountRepository, IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _hqYestardayTotalAmountRepository = hqYestardayTotalAmountRepository;

                _hqDaylyTotalAmountRepository = hqDaylyTotalAmountRepository;

                _hqWeeklyTotalAmountRepository = hqWeeklyTotalAmountRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(GetHqPeriodicCountQuery request, CancellationToken cancellationToken)
            {
                var report = new
                {
                    DailyTotalAmount = GetDaylyTotalAmount(),

                    YesterdayTotalAmount = GetYestardayTotalAmount(),

                    WeeklyTotalAmount = GetWeeklyTotalAmount()
                };

                return ResponseGenerator.Response("Success", _responseCode.OK, true, report);
            }

            private string GetDaylyTotalAmount()
            {
                return _hqDaylyTotalAmountRepository.FirstOrDefault().TotalAmountProcessed.ToString();
            }

            private string GetYestardayTotalAmount()
            {
                return _hqYestardayTotalAmountRepository.FirstOrDefault().TotalAmountProcessed.ToString();
            }

            private string GetWeeklyTotalAmount()
            {
                return _hqWeeklyTotalAmountRepository.FirstOrDefault().TotalAmountProcessed.ToString();
            }
        }
    }
}
