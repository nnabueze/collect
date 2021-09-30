using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
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

namespace ErcasCollect.Queries.Transaction
{
    public class GetAllBatchTransactionQuery : IRequest<SuccessfulResponse>
    {
        public class GetAllBatchTransactionQueryHandler : IRequestHandler<GetAllBatchTransactionQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<Batch> _batchRepository;

            private readonly ResponseCode _responseCode;

            public GetAllBatchTransactionQueryHandler(IGenericRepository<Batch> batchRepository, IOptions<ResponseCode> responseCode)
            {
                _batchRepository = batchRepository;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(GetAllBatchTransactionQuery request, CancellationToken cancellationToken)
            {
                List<ReadAllBatchTransactionDto> listOfBatch = new List<ReadAllBatchTransactionDto>();

                var batchList = await _batchRepository.FindAllInclude( x => x.IsDeleted == false, x => x.LevelOne, x => x.LevelTwo, x => x.Biller, x => x.User);

                if (batchList == null)

                    return ResponseGenerator.Response("Succesful", _responseCode.OK, true);

                foreach (var item in batchList)
                {
                    var addBatch = new ReadAllBatchTransactionDto()
                    {
                        BillerName = item.Biller.Name,

                        IsBatchClosed = item.IsBatchClosed,

                        IsSuccess = item.IsSuccess,

                        ItemCount = item.ItemCount,

                        LevelOneName = item.LevelOne.Name,

                        LevelTwoName = item.LevelTwo.Name,

                        OfflineBatchId = item.OfflineBatchId,

                        OfflineCreatedDate = item.OfflineCreatedDate.ToString(),

                        PaymentChannel = TypeAndChannelHelper.PaymentChannel((int)item.PaymentChannelId),

                        ReferenceKey = item.ReferenceKey,

                        TotalAmount = item.TotalAmount.ToString(),

                        TransactionType = TypeAndChannelHelper.TransactionType((int)item.TransactionTypeId),

                        UserName = item.User.Name

                    };

                    listOfBatch.Add(addBatch);
                }

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, listOfBatch);
            }
        }
    }
}
