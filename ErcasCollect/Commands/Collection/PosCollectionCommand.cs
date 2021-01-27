using AutoMapper;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Helpers.EnumClasses;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Collection
{
    public class PosCollectionCommand : IRequest<SuccessfulResponse>
    {
        public PosCollectionDto posCollectionDto { get; set; }

        public class PosCollectionCommandHandler : IRequestHandler<PosCollectionCommand, SuccessfulResponse>
        {
            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<Transaction> _transactionRepository;

            private readonly IGenericRepository<Batch> _BatchRepository;
            
            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<Pos> _posRespository;

            private readonly IGenericRepository<User> _userRepository;

            private readonly IMapper _mapper;

            public PosCollectionCommandHandler(IOptions<ResponseCode> responseCode, IGenericRepository<Transaction> transactionRepository, 
                
                IGenericRepository<Batch> batchRepository, IGenericRepository<Biller> billerRepository, IGenericRepository<Pos> posRespository, 
                
                IGenericRepository<User> userRepository, IMapper mapper)
            {
                _responseCode = responseCode.Value;

                _transactionRepository = transactionRepository;

                _BatchRepository = batchRepository;

                _billerRepository = billerRepository;

                _posRespository = posRespository;

                _userRepository = userRepository;

                _mapper = mapper;
            }

            public async Task<SuccessfulResponse> Handle(PosCollectionCommand request, CancellationToken cancellationToken)
            {
                var posRequestValidation = PosRequestValidation(request);

                if (posRequestValidation != null)
                {
                    return posRequestValidation;
                }

                var checkTransactionTotal = CheckTransactionTotal(request);

                if (checkTransactionTotal != null)
                {
                    return checkTransactionTotal;
                }

                var verifyCollectionLimit = VerifyCollectionLimit(request);

                if (verifyCollectionLimit != null)
                {
                    return verifyCollectionLimit;
                }

                //save batch
                var batchReferenceKay = await SaveBatchTransaction(request);
                //save transaction
                
                return null;

            }

            private void SaveTransactionItem(PosCollectionCommand request, string BatchReferenceKey)
            {

            }

            private async Task<string> SaveBatchTransaction(PosCollectionCommand request)
            {
                var totalAmount = GetTransactionTotal(request);

                var biller = GetBiller(request);

                var pos = GetPos(request);

                var user = GetUserId(request.posCollectionDto.UserId);

                var batch = new Batch()
                {
                    BillerId = biller.Id,
                    
                    ItemCount = Convert.ToInt16(request.posCollectionDto.ItemCount),

                    OfflineBatchId = request.posCollectionDto.OfflineBatchId,

                    PosId = pos.Id,

                    UserId = user.Id,

                    TotalAmount = totalAmount,

                    ReferenceKey = Helpers.IdGenerator.IdGenerator.RandomInt(15),

                    TransactionType = TypesOfTransaction.Collection,

                    PaymentChannel = PaymentChannels.Cash,

                    IsSuccess = true
                    
                };

                var savedBatch = await _BatchRepository.Add(batch);

                await _BatchRepository.CommitAsync();

                return savedBatch.ReferenceKey;
            }

            private SuccessfulResponse CheckTransactionTotal(PosCollectionCommand request)
            {
                decimal totalSum = GetTransactionTotal(request);

                if (totalSum != Convert.ToDecimal(request.posCollectionDto.TotalAmount))
                {
                    return ResponseGenerator.Response("Total amount not equal to batch total amount", _responseCode.NotFound, false);
                }

                return null;
            }

            private static decimal GetTransactionTotal(PosCollectionCommand request)
            {
                return request.posCollectionDto.TransactionItems.Sum(x => Convert.ToDecimal(x.Amount));
            }

            private SuccessfulResponse VerifyCollectionLimit(PosCollectionCommand request)
            {
                var user = GetUserId(request.posCollectionDto.UserId);

                var totalCollection = _BatchRepository.Find(x => x.UserId == user.Id && x.IsBatchClosed == false).Sum(x => x.TotalAmount);

                var tempTotalCollection = totalCollection + Convert.ToDecimal(request.posCollectionDto.TotalAmount);

                if (tempTotalCollection >= user.CollectionLimit)
                {
                    return ResponseGenerator.Response("User Llimit reached", _responseCode.NotFound, false);
                }

                return null;
            }

            private SuccessfulResponse PosRequestValidation(PosCollectionCommand request)
            {
                Biller biller = GetBiller(request);

                if (biller == null || biller.IsDeleted)
                {
                    return ResponseGenerator.Response("Invalid biller Id", _responseCode.NotFound, false);
                }

                Pos pos = GetPos(request);

                if (pos == null || !pos.IsActive)
                {
                    return ResponseGenerator.Response("Invalid pos Id or pos not active", _responseCode.NotFound, false);
                }

                var user = GetUserId(request.posCollectionDto.UserId);

                if (user == null || !user.IsActive)
                {
                    return ResponseGenerator.Response("Invalid user Id or use not active", _responseCode.NotFound, false);
                }

                return null;

            }

            private Pos GetPos(PosCollectionCommand request)
            {
                return _posRespository.FindFirst(x => x.ReferenceKey == request.posCollectionDto.PosId);
            }

            private Biller GetBiller(PosCollectionCommand request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request.posCollectionDto.BillerId);
            }

            private User GetUserId(string UserId)
            {
                var user = _userRepository.FindFirst(x => x.ReferenceKey == UserId);

                return user;
            }
        }
    }
}
