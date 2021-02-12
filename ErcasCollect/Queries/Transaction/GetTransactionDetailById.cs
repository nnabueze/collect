using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.Dto;
using ErcasCollect.Queries.Dto.ReadTransactionDto;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetTransactionDetailByIDQuery : IRequest<SuccessfulResponse>
    {
        private string _batchTransactionId;

        public GetTransactionDetailByIDQuery(string batchTransactionId)
        {
            _batchTransactionId = batchTransactionId;
        }

        public class GetTransactionDetailByIDHandler : IRequestHandler<GetTransactionDetailByIDQuery, SuccessfulResponse>
        {
            private readonly ITransactionRepository _transactionRepository;

            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<Batch> _batchRepository;

            private readonly IGenericRepository<CategoryTwoService> _categoryTwoServiceRepository;

            public GetTransactionDetailByIDHandler(ITransactionRepository transactionRepository, IOptions<ResponseCode> responseCode, IGenericRepository<Batch> batchRepository, IGenericRepository<CategoryTwoService> categoryTwoServiceRepository)
            {
                _transactionRepository = transactionRepository;

                _responseCode = responseCode.Value;

                _batchRepository = batchRepository;

                _categoryTwoServiceRepository = categoryTwoServiceRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetTransactionDetailByIDQuery request, CancellationToken cancellationToken)
            {
                List<ReadListTransactionDto> listOfTransaction = new List<ReadListTransactionDto>();

                var batch = await _batchRepository.FindSingleInclude( x => x.IsDeleted == false && x.ReferenceKey == request._batchTransactionId, x => x.Transactions);

                if (batch == null)

                    return ResponseGenerator.Response("Invalid Batch Transaction Id", _responseCode.NotFound, false);

                foreach (var item in batch.Transactions)
                {
                    var transaction = new ReadListTransactionDto()
                    {
                        Amount = item.Amount.ToString(),

                        BatchReferenceKey = request._batchTransactionId,

                        CategoryTwoServiceName = GetCategoryTwo((int)item.CategoryTwoServiceId),

                        PayerName = item.PayerName,

                        PayerPhone = item.PayerPhone,

                        ReferenceKey = item.ReferenceKey
                    };

                    listOfTransaction.Add(transaction);
                }

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, listOfTransaction);
            }

            private string GetCategoryTwo(int categoryTwoId)
            {
                var category = _categoryTwoServiceRepository.FindFirst(x => x.Id == categoryTwoId);

                if (category == null)

                    return null;

                return category.Name;
            }
        }
    }
}

