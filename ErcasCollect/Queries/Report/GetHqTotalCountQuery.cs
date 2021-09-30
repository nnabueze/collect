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

            private readonly IGenericRepository<HqBillerTotal> _hqBillerTotalRepository;

            private readonly IGenericRepository<HqYearlyTransactionTotal> _hqTransactionTotalRepository;

            private readonly IGenericRepository<HqTotalUser> _hqTotalUserRepository;

            private readonly IGenericRepository<HqTotalPos> _hqTotalPosRepository;

            private readonly IGenericRepository<HqAllBillersMonthlyTotalAmount> _hqAllBillersMonthlyTotalAmountRepository;

            private readonly IGenericRepository<HqMonthlyTransactionTotal> _hqMonthlyTransactionTotalRepository;

            private readonly IGenericRepository<HqAllBillersMonthlyCashAtHand> _hqAllBillersMonthlyCashAtHandRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public GetHqTotalCountQueryHandler(IGenericRepository<HqAllBillersYearlyTotalAmount> hqAllBillerYearlyTotalRepository, IMapper mapper, IOptions<ResponseCode> responseCode,

                IGenericRepository<HqBillerTotal> hqBillerTotalRepository, IGenericRepository<HqYearlyTransactionTotal> hqTransactionTotalRepository, IGenericRepository<HqTotalUser> hqTotalUserRepository,

                IGenericRepository<HqTotalPos> hqTotalPosRepository, IGenericRepository<HqAllBillersMonthlyTotalAmount> hqAllBillersMonthlyTotalAmountRepository, 
                
                IGenericRepository<HqMonthlyTransactionTotal> hqMonthlyTransactionTotalRepository, IGenericRepository<HqAllBillersMonthlyCashAtHand> hqAllBillersMonthlyCashAtHandRepository)
            {
                _hqAllBillerYearlyTotalRepository = hqAllBillerYearlyTotalRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;

                _hqBillerTotalRepository = hqBillerTotalRepository;

                _hqTransactionTotalRepository = hqTransactionTotalRepository;

                _hqTotalUserRepository = hqTotalUserRepository;

                _hqTotalPosRepository = hqTotalPosRepository;

                _hqAllBillersMonthlyTotalAmountRepository = hqAllBillersMonthlyTotalAmountRepository;

                _hqMonthlyTransactionTotalRepository = hqMonthlyTransactionTotalRepository;

                _hqAllBillersMonthlyCashAtHandRepository = hqAllBillersMonthlyCashAtHandRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetHqTotalCountQuery request, CancellationToken cancellationToken)
            {
                var hqReportCount = new
                {
                    MonthlyTotalAmount = GetHqBillerMonthlyTotalAmouth(),

                    MonthlyCashAtHand = GetHqMonthlyCashAtHand(),

                    TotalBiller = GetBillerTotal(),

                    MonthlyTotalTransaction = GetHqMonthlyTransactionTotal(),

                    TotalUser = GetTotalUser(),

                    TotalPos = GetTotalPos()
                };

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, hqReportCount);
            }

            private string GetHqMonthlyCashAtHand()
            {
                return _hqAllBillersMonthlyCashAtHandRepository.FirstOrDefault().TotalAmount.ToString();
            }

            private string GetHqMonthlyTransactionTotal()
            {
                return _hqMonthlyTransactionTotalRepository.FirstOrDefault().TotalTransaction.ToString();
            }

            private string GetHqBillerMonthlyTotalAmouth()
            {
                return _hqAllBillersMonthlyTotalAmountRepository.FirstOrDefault().TotalAmountProcessed.ToString();
            }

            private string GetYearlyAmount()
            {
                return _hqAllBillerYearlyTotalRepository.FirstOrDefault().TotalAmountProcessed.ToString();
            }

            private string GetBillerTotal()
            {
                return _hqBillerTotalRepository.FirstOrDefault().TotalBiller.ToString();
            }

            private string GetTotalUser()
            {
                return _hqTotalUserRepository.FirstOrDefault().TotalUser.ToString();
            }

            private string GetTotalTransactions()
            {
                return _hqTransactionTotalRepository.FirstOrDefault().TotalTransaction.ToString();
            }

            private string GetTotalPos()
            {
                return _hqTotalPosRepository.FirstOrDefault().TotalPos.ToString();
            }
        }
    }
}
