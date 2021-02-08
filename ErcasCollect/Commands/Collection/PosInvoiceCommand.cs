using AutoMapper;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Collection
{
    public class PosInvoiceCommand : IRequest<SuccessfulResponse>
    {
        public PosInvoiceDto posInvoiceDto { get; set; }

        public class PosInvoiceCommandHandler : IRequestHandler<PosInvoiceCommand, SuccessfulResponse>
        {
            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<Transaction> _transactionRepository;

            private readonly IGenericRepository<Batch> _BatchRepository;

            private readonly IGenericRepository<Pos> _posRespository;

            private readonly IGenericRepository<User> _userRepository;

            private readonly IMapper _mapper;

            private readonly IGenericRepository<CategoryTwoService> _categoryTwoServiceRepository;

            private readonly IGenericRepository<LevelTwo> _levelTwoRepository;

            private readonly IGenericRepository<CloseBatchTransaction> _closeBatchTransactionRepository;

            public async Task<SuccessfulResponse> Handle(PosInvoiceCommand request, CancellationToken cancellationToken)
            {
                //auto mapper

                //Get and check level two
                var levelTwo = await GetLevelTwo(request.posInvoiceDto.LevelTwoId);

                if (levelTwo == null)

                    return ResponseGenerator.Response("Invalid level two Id", _responseCode.NotFound, false);

                var itemCount = GetItemCount(request);

                if(Convert.ToInt32(request.posInvoiceDto.ItemCount) != itemCount)

                    return ResponseGenerator.Response("Item count not correct", _responseCode.NotAccepted, false);

                var pos = GetPos(request.posInvoiceDto.PosId);

                if(pos == null)

                    return ResponseGenerator.Response("Invalid pos  Id or pos not activated", _responseCode.NotAccepted, false);

                var user = await GetUserId(request);

                if(user == null)

                    return ResponseGenerator.Response("Invalid user Id", _responseCode.NotAccepted, false);

                var userCheck = await UserCheck(request, user);

                if (userCheck != null)

                    return userCheck;


                //add batch tranasction
                var savedBatch = await AddBatchTransaction(request, levelTwo, user.Id, pos.Id);

                //add trabsaction

                await SaveTransaction(request, savedBatch.ReferenceKey);

                //add close batch
                var savedClocsBatchTransaction = await SaveCloseBatchTransaction(request, levelTwo, user.Id);

                UpdateBatchTransaction(savedBatch.Id, savedClocsBatchTransaction.Id, user);

                //send email

                //retyrn response
                return ResponseGenerator.Response("Sucessful", _responseCode.OK, true, new { InvoiceId = savedClocsBatchTransaction.ReferenceKey});
            }

            private void UpdateBatchTransaction(int batchId, int closeBatchId, User user)
            {

                var item = _BatchRepository.FindFirst(x => x.Id == batchId && x.IsBatchClosed == false);

                item.IsBatchClosed = true;

                item.CloseBatchTransactionId = closeBatchId;

                item.ModifiedDate = DateTime.UtcNow;

                item.ModifiedBy = user.Id;

                _BatchRepository.Update(item);

                _BatchRepository.CommitAsync();
            }

            private async Task<CloseBatchTransaction> SaveCloseBatchTransaction(PosInvoiceCommand request, LevelTwo levelTwo, int userId)
            {
                var saveCloseBatchTransaction = new CloseBatchTransaction()
                {
                    BillerId = levelTwo.BillerId,

                    CreatedDate = DateTime.UtcNow,

                    IsPaid = false,

                    LevelOneId = levelTwo.LevelOneId,

                    LevelTwoId = levelTwo.Id,

                    PaymentChannelId = 1,

                    ReferenceKey = Helpers.IdGenerator.IdGenerator.RandomInt(15),

                    TotalAmount = Convert.ToDecimal(request.posInvoiceDto.TotalAmount),

                    UserId = userId,

                    TransactionTypeId = 4
                };

                var savedBatch = await _closeBatchTransactionRepository.Add(saveCloseBatchTransaction);

                await _closeBatchTransactionRepository.CommitAsync();

                return savedBatch;
            }

            private async Task SaveTransaction(PosInvoiceCommand request, string batchId)
            {
                foreach (var item in request.posInvoiceDto.Invoices)
                {
                    var trasaction = new Transaction()
                    {
                        Amount = Convert.ToDecimal(item.Amount),

                        BatchReferenceKey = batchId,

                        OfflineBatchId = request.posInvoiceDto.OfflineBatchTransactionId,

                        CategoryTwoServiceId = GetCategoryTwo(item.CategoryTwoId).Id,

                        CreatedDate = DateTime.UtcNow,

                        PayerName = item.PayerName,

                        PayerPhone = item.PayerPhone,

                        ReferenceKey = Helpers.IdGenerator.IdGenerator.RandomInt(15)                        
                    };

                    await _transactionRepository.Add(trasaction);
                }

                await _transactionRepository.CommitAsync();
            }

            private async Task<CategoryTwoService> GetCategoryTwo(string categoryTwoId)
            {
                return await _categoryTwoServiceRepository.FindSingleInclude(x => x.ReferenceKey == categoryTwoId, x => x.CategoryOneService);
            }

            private async Task<LevelTwo> GetLevelTwo(string levelTwoId)
            {
                return await _levelTwoRepository.FindSingleInclude(x => x.ReferenceKey == levelTwoId, x => x.Biller, x => x.LevelOne);
            }

            private async Task<Batch> AddBatchTransaction(PosInvoiceCommand request, LevelTwo levelTwo, int userId, int posId)
            {
                var batch = new Batch()
                {
                    BillerId = levelTwo.BillerId,

                    IsSuccess = true,

                    OfflineBatchId = request.posInvoiceDto.OfflineBatchTransactionId,

                    OfflineCreatedDate = Convert.ToDateTime(request.posInvoiceDto.OfflineCreatedDate),

                    CreatedDate = DateTime.UtcNow,

                    ItemCount = Convert.ToInt32(request.posInvoiceDto.ItemCount),

                    LevelOneId = levelTwo.LevelOneId,

                    LevelTwoId = levelTwo.Id,

                    PaymentChannelId = 1,

                    UserId = userId,

                    ReferenceKey = Helpers.IdGenerator.IdGenerator.RandomInt(15),

                    TotalAmount = Convert.ToDecimal(request.posInvoiceDto.TotalAmount),

                    TransactionTypeId = 4,

                    PosId = posId

                };

                var saveBatch = await _BatchRepository.Add(batch);

                await _BatchRepository.CommitAsync();

                return saveBatch;
            }

            private async Task<SuccessfulResponse> UserCheck(PosInvoiceCommand request, User user)
            {
               
                if(user.RoleId != 4 || user.RoleId != 5)

                    return ResponseGenerator.Response("User is not an agent", _responseCode.NotAccepted, false);

                var totalCollection = _BatchRepository.Find(x => x.UserId == user.Id && x.IsBatchClosed == false).Sum(x => x.TotalAmount);

                var tempTotalCollection = totalCollection + Convert.ToDecimal(request.posInvoiceDto.TotalAmount);

                if (tempTotalCollection >= user.CollectionLimit)
                {
                    return ResponseGenerator.Response("User Llimit reached", _responseCode.NotFound, false);
                }

                return null;
            }

            private async Task<User> GetUserId(PosInvoiceCommand request)
            {
                var user = await _userRepository.FindSingleInclude(x => x.ReferenceKey == request.posInvoiceDto.UserId && x.IsActive == true, x => x.Role);

                return user;
            }

            private Pos GetPos(string posId)
            {
                return _posRespository.FindFirst(x => x.ReferenceKey == posId && x.IsActive == true);
            }

            private int GetItemCount(PosInvoiceCommand request)
            {
                return request.posInvoiceDto.Invoices.Count();
            }
        }
    }
}
