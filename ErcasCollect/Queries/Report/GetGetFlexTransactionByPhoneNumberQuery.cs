using AutoMapper;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
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
    public class GetGetFlexTransactionByPhoneNumberQuery : IRequest<SuccessfulResponse>
    {
        private string _userPhonenumber;

        public GetGetFlexTransactionByPhoneNumberQuery(string userPhonenumber)
        {
            _userPhonenumber = userPhonenumber;
        }

        public class GetGetFlexTransactionByPhoneNumberQueryHandler : IRequestHandler<GetGetFlexTransactionByPhoneNumberQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<Batch> _batchRepository;

            private readonly ITransactionRepository _transactionRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public GetGetFlexTransactionByPhoneNumberQueryHandler(IGenericRepository<Batch> batchRepository, ITransactionRepository transactionRepository, 
                
                IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _batchRepository = batchRepository;

                _transactionRepository = transactionRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(GetGetFlexTransactionByPhoneNumberQuery request, CancellationToken cancellationToken)
            {
                List<ReadFlexTransactionDto> transactionList = new List<ReadFlexTransactionDto>();

                var transactions = await _transactionRepository.FindAllInclude(x => x.PayerPhone == request._userPhonenumber, x => x.Batch);

                if (transactions == null)

                    return ResponseGenerator.Response("No transaction by flex", _responseCode.OK, true);

                foreach (var item in transactions)
                {
                    var report = new ReadFlexTransactionDto()
                    {
                        Amount = item.Amount,

                        DateProcessed = item.CreatedDate.ToString(),

                        IsSuccess = item.Batch.IsSuccess,

                        PayerName = item.PayerName,

                        PayerPhone = item.PayerPhone,

                        ReferenceKey = item.ReferenceKey
                    };

                    switch (item.Batch.PaymentProcessorId)
                    {
                        case 1:
                            report.ProcessedBy = "Pos";

                            break;
                        case 2:
                            report.ProcessedBy = "Nibss";

                            break;
                        case 3:
                            report.ProcessedBy = "Interswitch";

                            break;
                        case 4:
                            report.ProcessedBy = "Remitta";

                            break;
                        case 5:
                            report.ProcessedBy = "PayStar";

                            break;

                        default:
                            break;
                    }

                    transactionList.Add(report);
                }

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, transactionList);
            }
        }
    }
}
