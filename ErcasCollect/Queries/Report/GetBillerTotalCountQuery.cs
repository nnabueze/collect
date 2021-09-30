using AutoMapper;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
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
    public class GetBillerTotalCountQuery : IRequest<SuccessfulResponse>
    {
        private string _billerId;

        public GetBillerTotalCountQuery(string billerId)
        {
            _billerId = billerId;
        }

        public class GetBillerTotalCountQueryHandler : IRequestHandler<GetBillerTotalCountQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<BillerYesterdayTotalAmountProcessed> _billerYesterdayTotalAmountProcessedRepository;

            private readonly IGenericRepository<MonthlyTopPerformingBillers> _monthlyTopPerformingBillersRepository;

            private readonly IGenericRepository<BillerMonthlyTotalTransactions> _billerMonthlyTotalTransactionsRepository;

            private readonly IGenericRepository<BillerTodayTotalAmountProcessed> _billerTodayTotalAmountProcessedRepository;

            private readonly IGenericRepository<BillerTotalCashAtHand> _billerTotalCashAtHandRepository;

            private readonly IGenericRepository<BillerTotalUser> _billerTotalUserRepository;

            private readonly IGenericRepository<BillerWeeklyTotalAmountProcessed> _billerWeeklyTotalAmountProcessedRepository;

            public GetBillerTotalCountQueryHandler(IGenericRepository<Biller> billerRepository, IMapper mapper, IOptions<ResponseCode> responseCode, 
                
                IGenericRepository<BillerYesterdayTotalAmountProcessed> billerYesterdayTotalAmountProcessedRepository, IGenericRepository<MonthlyTopPerformingBillers> monthlyTopPerformingBillersRepository, 
                
                IGenericRepository<BillerMonthlyTotalTransactions> billerMonthlyTotalTransactionsRepository, IGenericRepository<BillerTodayTotalAmountProcessed> billerTodayTotalAmountProcessedRepository, 
                
                IGenericRepository<BillerTotalCashAtHand> billerTotalCashAtHandRepository, IGenericRepository<BillerTotalUser> billerTotalUserRepository, 
                
                IGenericRepository<BillerWeeklyTotalAmountProcessed> billerWeeklyTotalAmountProcessedRepository)
            {
                _billerRepository = billerRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;

                _billerYesterdayTotalAmountProcessedRepository = billerYesterdayTotalAmountProcessedRepository;

                _monthlyTopPerformingBillersRepository = monthlyTopPerformingBillersRepository;

                _billerMonthlyTotalTransactionsRepository = billerMonthlyTotalTransactionsRepository;

                _billerTodayTotalAmountProcessedRepository = billerTodayTotalAmountProcessedRepository;

                _billerTotalCashAtHandRepository = billerTotalCashAtHandRepository;

                _billerTotalUserRepository = billerTotalUserRepository;

                _billerWeeklyTotalAmountProcessedRepository = billerWeeklyTotalAmountProcessedRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetBillerTotalCountQuery request, CancellationToken cancellationToken)
            {
                //auto mapper

                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request._billerId);

                if (biller == null)

                    return ResponseGenerator.Response("Invalid biller Id.", _responseCode.NotFound, false);

                var report = new
                {
                    BillerMonthlyAmountProcessed = GetBillerMonthlyAmountProcessed(biller),

                    BillerMonthlyCashAtHand = GetBillerMonthlyCashAtHand(biller),

                    BillerMonthlyTotalTransaction = GetBillerMonthlyTotalTransaction(biller),

                    BillerTotalUser = GetBillerTotalUser(biller),

                    BillerTodayTotalAmountProcessed = GetTodayTotalAmountProcessed(biller),

                    BillerYesterdayTotalAmountProcessed = GetYesterdayTotalAmountProcessed(biller),

                    BillerWeeklyTotalAmountProcessed = GetWeeklyTotalAmountProcessed(biller)

                };

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, report);
            }

            private string GetBillerMonthlyAmountProcessed(Biller biller)
            {
                return _monthlyTopPerformingBillersRepository.FindFirst(x => x.BillerId == biller.Id).TotalAmount.ToString();
            }

            private string GetBillerMonthlyCashAtHand(Biller biller)
            {
                return _billerTotalCashAtHandRepository.FindFirst(x => x.BillerId == biller.Id).TotalAmount.ToString();
            }

            private string GetBillerMonthlyTotalTransaction(Biller biller)
            {
                return _billerMonthlyTotalTransactionsRepository.FindFirst(x => x.BillerId == biller.Id).TotalTransaction.ToString();
            }

            private string GetBillerTotalUser(Biller biller)
            {
                return _billerTotalUserRepository.FindFirst(x => x.BillerId == biller.Id).TotalUser.ToString();
            }

            private string GetTodayTotalAmountProcessed(Biller biller)
            {
                return _billerTodayTotalAmountProcessedRepository.FindFirst(x => x.BillerId == biller.Id).TotalAmount.ToString();
            }

            private string GetYesterdayTotalAmountProcessed(Biller biller)
            {
                return _billerYesterdayTotalAmountProcessedRepository.FindFirst(x => x.BillerId == biller.Id).TotalAmount.ToString();
            }

            private string GetWeeklyTotalAmountProcessed(Biller biller)
            {
                return _billerWeeklyTotalAmountProcessedRepository.FindFirst(x => x.BillerId == biller.Id).TotalAmount.ToString();
            }
        }
    }
}
