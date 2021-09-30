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
    public class GetTransactionByBillerIDQuery : IRequest<SuccessfulResponse>
    {
        private string _billerId;

        public GetTransactionByBillerIDQuery(string billerId)
        {
            _billerId = billerId;
        }

        public class GetTransactionByBillerIDHandler : IRequestHandler<GetTransactionByBillerIDQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<Batch> _batchRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly ResponseCode _responseCode;

            public GetTransactionByBillerIDHandler(IGenericRepository<Batch> batchRepository, IOptions<ResponseCode> responseCode, IGenericRepository<Biller> billerRepository)
            {
                _batchRepository = batchRepository;

                _responseCode = responseCode.Value;

                _billerRepository = billerRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetTransactionByBillerIDQuery request, CancellationToken cancellationToken)
            {
                List<ReadAllBatchTransactionDto> listOfBatch = new List<ReadAllBatchTransactionDto>();

                var biller = GetBiller(request._billerId);

                if (biller == null)

                    return ResponseGenerator.Response("Invalid billerId", _responseCode.NotFound, false);

                var batchList = await _batchRepository.FindAllInclude(x => x.IsDeleted == false && x.BillerId == biller.Id, x => x.LevelOne, x => x.LevelTwo, x => x.Biller, x => x.User);

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

            private Biller GetBiller(string billerId)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == billerId);
            }
        }
    }
}

