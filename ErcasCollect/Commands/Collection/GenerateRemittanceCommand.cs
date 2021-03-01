

using AutoMapper;
using ErcasCollect.Commands.Dto;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Helpers.EnumClasses;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.CollectionCommand
{
    public partial class GenerateRemittanceCommand : IRequest<SuccessfulResponse>
    {
        public GenerateRemittanceDto transactionDto { get; set; }

        public class GenerateRemittanceCommandHandler : IRequestHandler<GenerateRemittanceCommand, SuccessfulResponse>
        {

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<CloseBatchTransaction> _closeBatchTransactionRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<Pos> _posRespository;

            private readonly IGenericRepository<Transaction> _transactionRespository;

            private readonly IGenericRepository<User> _userRepository;

            private readonly IGenericRepository<Batch> _BatchRepository;

            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<LevelTwo> _levelTwoRepository;

            private readonly NameConstant _nameConstant;

            private readonly IWebCallService _webCallService;

            private readonly WebEndpoint _webEndpoint;

            public GenerateRemittanceCommandHandler(IMapper mapper, IOptions<ResponseCode> responseCode, IGenericRepository<CloseBatchTransaction> closeBatchTransaction,

                IGenericRepository<Biller> billerRepository, IGenericRepository<Pos> posRespository, IGenericRepository<Transaction> transactionRespository,

                IGenericRepository<User> userRepository, IGenericRepository<Batch> batchRepository, IGenericRepository<LevelOne> levelOneRepository,

                IGenericRepository<LevelTwo> levelTwoRepository, IOptions<NameConstant> nameConstant, IWebCallService webCallService, IOptions<WebEndpoint> webEndpoint)
            {
                _mapper = mapper;

                _responseCode = responseCode.Value;

                _closeBatchTransactionRepository = closeBatchTransaction;

                _billerRepository = billerRepository;

                _posRespository = posRespository;

                _transactionRespository = transactionRespository;

                _userRepository = userRepository;

                _BatchRepository = batchRepository;

                _levelOneRepository = levelOneRepository;

                _levelTwoRepository = levelTwoRepository;

                _nameConstant = nameConstant.Value;

                _webCallService = webCallService;

                _webEndpoint = webEndpoint.Value;
            }

            public async Task<SuccessfulResponse> Handle(GenerateRemittanceCommand request, CancellationToken cancellationToken)
            {

                //verify pos
                var posRequestValidation = PosRequestValidation(request);

                if (posRequestValidation != null)
                {
                    return posRequestValidation;
                }

                //check for pending remittance
                var checkCloseBatch = CheckCloseBatchTransaction(request);

                if (checkCloseBatch != null)
                {
                    return checkCloseBatch;
                }

                var closeBatchId = SaveCloseBachTransaction(request);

                if(closeBatchId == null)

                    return ResponseGenerator.Response("Error generating ERN", _responseCode.NotAccepted, false);

                //send sms

                return ResponseGenerator.Response("Remittance Generated", _responseCode.RemmitanceGenerated, true, new { ClosedBatchTransactionId = closeBatchId});
            }

            private async Task<string> SaveCloseBachTransaction(GenerateRemittanceCommand request)
            {
                var totalAmount = await TotalBatchTransaction(request);

                var biller = GetBiller(request);

                var user = GetUserId(request.transactionDto.UserId);

                var referenceKey = Helpers.IdGenerator.IdGenerator.RandomInt(15);

                var ern = await GetErn(biller, referenceKey);

                if (ern == null)

                    return null;

                var closeBatch = new CloseBatchTransaction()
                {
                    BillerId = biller.Id,

                    LevelOneId = user.LevelOneId,

                    LevelTwoId = user.LevelTwoId,

                    UserId = user.Id,

                    TotalAmount = totalAmount,

                    PaymentChannelId = 1,

                    TransactionTypeId = 2,

                    ReferenceKey = ern
                };

                var saveCloseBatch = await _closeBatchTransactionRepository.Add(closeBatch);

                await _closeBatchTransactionRepository.CommitAsync();

                UpdateBatchTransaction(request, saveCloseBatch.Id);

                return referenceKey;
            }

            private async Task<string> GetErn(Biller biller, string referenceKey)
            {
                var json = JsonConvert.SerializeObject(new
                {

                    userName = biller.GatewayUsername,

                    keyVector = biller.GatewayKeyVector,

                    secretKey = biller.GatewaySecretKey,

                    transactionIdentify = referenceKey

                });
                ///Generate ERN
                var ernResponse = await _webCallService.PostDataCall(_webEndpoint.GenerateERNUrl, json);

                var ernObjectserilized = JsonXmlObjectConverter.Deserialize<GenerateErnDto>(ernResponse);

                return ernObjectserilized.data.generateERN;
            }

            private void UpdateBatchTransaction(GenerateRemittanceCommand request, int closeBatchId)
            {
                var user = GetUserId(request.transactionDto.UserId);

                var batchs = _BatchRepository.Find(x => x.UserId == user.Id && x.IsBatchClosed == false);

                foreach (var item in batchs)
                {
                    item.IsBatchClosed = true;

                    item.CloseBatchTransactionId = closeBatchId;

                    item.ModifiedDate = DateTime.UtcNow;

                    item.ModifiedBy = user.Id;

                     _BatchRepository.Update(item);

                    _BatchRepository.CommitAsync();
                }
            }

            private async Task<decimal> TotalBatchTransaction(GenerateRemittanceCommand request)
            {
                var user = GetUserId(request.transactionDto.UserId);

                return _BatchRepository.Find(x => x.UserId == user.Id && x.IsBatchClosed == false).Sum(x => x.TotalAmount);
            }

            private SuccessfulResponse CheckCloseBatchTransaction(GenerateRemittanceCommand request)
            {
                var user = GetUserId(request.transactionDto.UserId);

                var closeBatchTransaction = _closeBatchTransactionRepository.FindFirst(x => x.UserId == user.Id && x.IsPaid == false);

                if (closeBatchTransaction != null)
                {
                    return ResponseGenerator.Response("Pending Close Batch Transaction", _responseCode.NotAccepted, false);
                }

                return null;
            }

            private SuccessfulResponse PosRequestValidation(GenerateRemittanceCommand request )
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

                var user = GetUserId(request.transactionDto.UserId);

                if (user == null || !user.IsActive)
                {
                    return ResponseGenerator.Response("Invalid user Id or use not active", _responseCode.NotFound, false);
                }

                return null;

            }

            private Pos GetPos(GenerateRemittanceCommand request)
            {
                return _posRespository.FindFirst(x => x.ReferenceKey == request.transactionDto.PosId);
            }

            private Biller GetBiller(GenerateRemittanceCommand request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request.transactionDto.BillerId);
            }

            private User GetUserId(string UserId)
            {
                var user = _userRepository.FindFirst(x => x.ReferenceKey == UserId);

                return user;
            }
        }
    }
}