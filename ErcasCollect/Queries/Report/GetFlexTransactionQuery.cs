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
    public class GetFlexTransactionQuery : IRequest<SuccessfulResponse>
    {
        public class GetFlexTransactionQueryHandler : IRequestHandler<GetFlexTransactionQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<MonthlyFlexSuccessCount> _monthlyFlexSuccessCountRepository;

            private readonly IGenericRepository<MonthlyFlexFailedCount> _monthlyFlexFailedCountRepository;

            private readonly IGenericRepository<MonthlyFlexTotalAmount> _monthlyFlexTotalAmountRepository;

            private readonly IGenericRepository<MonthlyFlexTransactionCount> _monthlyFlexTransactionCountRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public GetFlexTransactionQueryHandler(IGenericRepository<MonthlyFlexSuccessCount> monthlyFlexSuccessCountRepository, IGenericRepository<MonthlyFlexFailedCount> monthlyFlexFailedCountRepository, 
                
                IGenericRepository<MonthlyFlexTotalAmount> monthlyFlexTotalAmountRepository, IGenericRepository<MonthlyFlexTransactionCount> monthlyFlexTransactionCountRepository, 
                
                IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _monthlyFlexSuccessCountRepository = monthlyFlexSuccessCountRepository;

                _monthlyFlexFailedCountRepository = monthlyFlexFailedCountRepository;

                _monthlyFlexTotalAmountRepository = monthlyFlexTotalAmountRepository;

                _monthlyFlexTransactionCountRepository = monthlyFlexTransactionCountRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(GetFlexTransactionQuery request, CancellationToken cancellationToken)
            {
                var report = new
                {
                    SuccessCount = GetFlexSuccessCount(),

                    FailedCount = GetFlexFailedCount(),

                    TransactionCount = GetFlexTotalTransaction(),

                    TotalAmount = GetFlexTotalAmount()
                };

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, report);
            }

            private string GetFlexSuccessCount()
            {
                return _monthlyFlexSuccessCountRepository.FirstOrDefault().TotalTransaction.ToString();
            }

            private string GetFlexFailedCount()
            {
                return _monthlyFlexFailedCountRepository.FirstOrDefault().TotalTransaction.ToString();
            }

            private string GetFlexTotalTransaction()
            {
                return _monthlyFlexTransactionCountRepository.FirstOrDefault().TotalTransaction.ToString();
            }

            private string GetFlexTotalAmount()
            {
                return _monthlyFlexTotalAmountRepository.FirstOrDefault().TotalAmountProcessed.ToString();
            }
        }
    }
}
