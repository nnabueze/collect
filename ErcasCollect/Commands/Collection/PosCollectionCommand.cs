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

            private readonly IGenericRepository<CategoryTwoService> _categoryTwoServiceRepository;

            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<LevelTwo> _levelTwoRepository;

            private readonly IGenericRepository<CloseBatchTransaction> _closeBatchTransactionRepository;

            public PosCollectionCommandHandler(IOptions<ResponseCode> responseCode, IGenericRepository<Transaction> transactionRepository,

                IGenericRepository<Batch> batchRepository, IGenericRepository<Biller> billerRepository, IGenericRepository<Pos> posRespository,

                IGenericRepository<User> userRepository, IMapper mapper, IGenericRepository<CategoryTwoService> categoryTwoServiceRepository,

                IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<LevelTwo> levelTwoRepository, 
                
                IGenericRepository<CloseBatchTransaction> closeBatchTransactionRepository)
            {
                _responseCode = responseCode.Value;

                _transactionRepository = transactionRepository;

                _BatchRepository = batchRepository;

                _billerRepository = billerRepository;

                _posRespository = posRespository;

                _userRepository = userRepository;

                _mapper = mapper;

                _categoryTwoServiceRepository = categoryTwoServiceRepository;

                _levelOneRepository = levelOneRepository;

                _levelTwoRepository = levelTwoRepository;

                _closeBatchTransactionRepository = closeBatchTransactionRepository;
            }

            public async Task<SuccessfulResponse> Handle(PosCollectionCommand request, CancellationToken cancellationToken)
            {
                var posRequestValidation = await PosRequestValidation(request);

                if (posRequestValidation != null)
                {
                    return posRequestValidation;
                }

                var checkLevels = await CheckLevelOneAndTwo(request);

                if (checkLevels != null)
                {
                    return checkLevels;
                }

                var checkCloseBatch = CheckCloseBatchTransaction(request);

                if (checkCloseBatch != null)
                {
                    return checkCloseBatch;
                }

                var checkTransactionTotal = CheckTransactionTotal(request);

                if (checkTransactionTotal != null)
                {
                    return checkTransactionTotal;
                }

                var verifyCollectionLimit = await VerifyCollectionLimit(request);

                if (verifyCollectionLimit != null)
                {
                    return verifyCollectionLimit;
                }

                var biller = GetBiller(request);

                var batchReferenceKay = await SaveBatchTransaction(request, biller);
                
                await SaveTransactionItem(request, batchReferenceKay, biller);

                return ResponseGenerator.Response("Transaction successful", _responseCode.TransactionSuccessful, true);

            }

            private async Task<SuccessfulResponse> CheckLevelOneAndTwo(PosCollectionCommand request)
            {
                LevelOne levelOne = GetLevelOne(request);

                LevelTwo levelTwo = GetLevelTwo(request);

                var user = await GetUserId(request.posCollectionDto.UserId);

                if (levelOne != null && user.LevelOneId != levelOne.Id)
                {
                    return ResponseGenerator.Response("User does not belong  to level one", _responseCode.NotAccepted, false);
                }

                if (levelTwo != null && user.LevelTwoId != levelTwo.Id)
                {
                    return ResponseGenerator.Response("User does not belong  to level two", _responseCode.NotAccepted, false);
                }

                return null;
            }

            private SuccessfulResponse CheckCloseBatchTransaction(PosCollectionCommand request)
            {
                var user = GetUserId(request.posCollectionDto.UserId);

                var closeBatchTransaction = _closeBatchTransactionRepository.FindFirst(x => x.UserId == user.Id && x.IsPaid == false);

                if(closeBatchTransaction != null)
                {
                    return ResponseGenerator.Response("Pending Close Batch Transaction", _responseCode.NotAccepted, false);
                }

                return null;
            }

            private LevelTwo GetLevelTwo(PosCollectionCommand request)
            {
                return _levelTwoRepository.FindFirst(x => x.ReferenceKey == request.posCollectionDto.LevelTwoId);
            }

            private LevelOne GetLevelOne(PosCollectionCommand request)
            {
                return _levelOneRepository.FindFirst(x => x.ReferenceKey == request.posCollectionDto.LevelOneId);
            }

            private int CheckItemCount(PosCollectionCommand request)
            {
                return request.posCollectionDto.TransactionItems.Count();
            }

            private async Task SaveTransactionItem(PosCollectionCommand request, int batchReferenceKey, Biller biller)
            {
                foreach (var item in request.posCollectionDto.TransactionItems)
                {
                    var categoryTwoId = GetCategoryTwo(item.CategoryTwoId);

                    var transaction = new Transaction()
                    {
                        Amount = Convert.ToDecimal(item.Amount),

                        BatchId = batchReferenceKey,

                        CategoryTwoServiceId = categoryTwoId,

                        OfflineBatchId = request.posCollectionDto.OfflineBatchId,

                        PayerName = item.PayerName,

                        PaymentChannelId = 1,

                        PayerPhone = item.PayerPhone,

                        ReferenceKey = JsonXmlObjectConverter.GetBillerRandomString(biller.Abbreviation, 15)
                    };

                    await _transactionRepository.Add(transaction);
                }

                await _transactionRepository.CommitAsync();
            }

            private int GetCategoryTwo(string categoryTwoId)
            {
                return _categoryTwoServiceRepository.FindFirst(x => x.ReferenceKey == categoryTwoId).Id;
            }

            private async Task<int> SaveBatchTransaction(PosCollectionCommand request, Biller biller)
            {
                var totalAmount = GetTransactionTotal(request);                

                var pos = GetPos(request);

                var user = GetUserId(request.posCollectionDto.UserId);

                var levelOne = GetLevelOne(request);

                var levelTwo = GetLevelTwo(request);

                var batch = new Batch()
                {
                    BillerId = biller.Id,
                    
                    ItemCount = CheckItemCount(request),

                    OfflineBatchId = request.posCollectionDto.OfflineBatchId,

                    PosId = pos.Id,

                    UserId = user.Id,

                    TotalAmount = totalAmount,

                    LevelOneId = levelOne.Id,

                    LevelTwoId = levelTwo.Id,

                    ReferenceKey = JsonXmlObjectConverter.GetBillerRandomString(biller.Abbreviation, 15),

                    TransactionTypeId = 1,

                    PaymentChannelId = 1,

                    OfflineCreatedDate = Convert.ToDateTime(request.posCollectionDto.OfflineCreatedDate),

                    IsSuccess = true
                    
                };

                var savedBatch = await _BatchRepository.Add(batch);

                await _BatchRepository.CommitAsync();

                return savedBatch.Id;
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

            private async Task<SuccessfulResponse> VerifyCollectionLimit(PosCollectionCommand request)
            {
                var user = await GetUserId(request.posCollectionDto.UserId);

                var totalCollection = _BatchRepository.Find(x => x.UserId == user.Id && x.IsBatchClosed == false).Sum(x => x.TotalAmount);

                var tempTotalCollection = totalCollection + Convert.ToDecimal(request.posCollectionDto.TotalAmount);

                if (tempTotalCollection >= user.CollectionLimit)
                {
                    return ResponseGenerator.Response("User Llimit reached", _responseCode.NotFound, false);
                }

                if(user.RoleId != 4 && user.RoleId != 5)

                    return ResponseGenerator.Response("User is not an agent", _responseCode.NotAccepted, false);

                return null;
            }

            private async Task<SuccessfulResponse> PosRequestValidation(PosCollectionCommand request)
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

                var user = await GetUserId(request.posCollectionDto.UserId);

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

            private async Task<User> GetUserId(string UserId)
            {
                var user = await _userRepository.FindSingleInclude(x => x.ReferenceKey == UserId, x => x.Role);

                return user;
            }
        }
    }
}
