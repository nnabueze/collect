using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Domain.Models.Nibss;
using ErcasCollect.Helpers;
using ErcasCollect.Helpers.EnumClasses;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.DataAccess.Repository
{
    public class EbillsNotification : IEbillsNotification
    {
        private readonly NameConstant _nameConstant;

        private readonly IGenericRepository<Biller> _billerRepository;

        private readonly IGenericRepository<BillerValidation> _billerValidationRepository;

        private readonly IGenericRepository<BillerEbillsProduct> _billerEbillsProductRepository;

        private readonly IGenericRepository<CloseBatchTransaction> _closeBatchTransactionRepository;

        private readonly IGenericRepository<LevelOne> _levelOneRepository;

        private readonly IGenericRepository<LevelTwo> _levelTwoRepository;

        private readonly ResponseCode _responseCode;

        private readonly IGenericRepository<Settlement> _settlementRepository;

        private readonly IGenericRepository<LevelDisplayName> _levelDisplayNameRepository;

        private Biller _billerDetail = null;

        public EbillsNotification(IOptions<NameConstant> nameConstant, IGenericRepository<Biller> billerRepository, IGenericRepository<BillerValidation> billerValidationRepository,

            IGenericRepository<BillerEbillsProduct> billerEbillsProductRepository, IGenericRepository<CloseBatchTransaction> closeBatchTransactionRepository,

            IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<LevelTwo> levelTwoRepository, IOptions<ResponseCode> responseCode, IGenericRepository<Settlement> settlementRepository, 
            
            IGenericRepository<LevelDisplayName> levelDisplayNameRepository)
        {
            _nameConstant = nameConstant.Value;

            _billerRepository = billerRepository;

            _billerValidationRepository = billerValidationRepository;

            _billerEbillsProductRepository = billerEbillsProductRepository;

            _closeBatchTransactionRepository = closeBatchTransactionRepository;

            _levelOneRepository = levelOneRepository;

            _levelTwoRepository = levelTwoRepository;

            _responseCode = responseCode.Value;

            _settlementRepository = settlementRepository;

            _levelDisplayNameRepository = levelDisplayNameRepository;
        }

        public async Task<NotificationResponse> Push(NotificationRequest request)
        {
            var saveSettlement = await SaveSettlement(request);

            if (saveSettlement == null)

                return NotificationFailedResponse(request, _nameConstant.DuplicateTransaction);

            await SaveClosedBatchTransaction(request, saveSettlement.TransactionNumber);

            return NotificationSuccessResponse(request);
        }

        private NotificationResponse NotificationSuccessResponse(NotificationRequest request)
        {
            var notificationResponse = new NotificationResponse()
            {
                BillerID = request.BillerID,

                ResponseCode = _responseCode.NibssSuccessCode,

                ResponseMessage = "Transaction Successful",

                SessionID = request.SessionID                
            };

            return notificationResponse;
        }

        public NotificationResponse NotificationFailedResponse(NotificationRequest request, string message)
        {
            var notificationResponse = new NotificationResponse()
            {
                BillerID = request.BillerID,

                ResponseCode = "401",

                ResponseMessage = message
            };

            return notificationResponse;
        }

        private async Task SaveClosedBatchTransaction(NotificationRequest request, string transactionId)
        {
            var closeBatchTransaction = _closeBatchTransactionRepository.FindFirst(x => x.ReferenceKey == transactionId && x.BillerId == _billerDetail.Id);

            if(closeBatchTransaction != null)
            {
                closeBatchTransaction.IsPaid = true;

                closeBatchTransaction.ModifiedDate = DateTime.UtcNow;

                closeBatchTransaction.PaymentChannel = PaymentChannels.Nibss;

                _closeBatchTransactionRepository.Update(closeBatchTransaction);

                await _closeBatchTransactionRepository.CommitAsync();
            }
            else
            {
                var savedBatchTransaction = new CloseBatchTransaction()
                {
                    BillerId = _billerDetail.Id,

                    IsPaid = true,

                    LevelOneId = GetLevelOneId(request),

                    LevelTwoId = GetLevelTwoId(request),

                    PaymentChannel = PaymentChannels.Nibss,

                    TotalAmount = Convert.ToDecimal(GetAmount(request)),

                    ReferenceKey = request.SessionID
                };

                await _closeBatchTransactionRepository.Add(savedBatchTransaction);

                await _closeBatchTransactionRepository.CommitAsync();
            }


        }

        private int GetLevelOneId(NotificationRequest request)
        {
            string levelOneStingId = string.Empty;

            var displayName = GetBillerDisplayname();

            for (int i = 0; i < request.Param.Count; i++)
            {
                if (request.Param[i].Key.Equals(displayName.LevelOneDisplayName + _nameConstant.LevelKeyIdentify))
                {
                    levelOneStingId = request.Param[i].Value;
                }
            }

            return _levelOneRepository.FindFirst(x => x.ReferenceKey == levelOneStingId).Id;
        }

        private int GetLevelTwoId(NotificationRequest request)
        {
            string levelTwoStingId = string.Empty;

            var displayName = GetBillerDisplayname();

            for (int i = 0; i < request.Param.Count; i++)
            {
                if (request.Param[i].Key.Equals(displayName.LevelTwoDisplayName + _nameConstant.LevelKeyIdentify))
                {
                    levelTwoStingId = request.Param[i].Value;
                }
            }

            return _levelTwoRepository.FindFirst(x => x.ReferenceKey == levelTwoStingId).Id;
        }

        private LevelDisplayName GetBillerDisplayname()
        {
            return _levelDisplayNameRepository.FindFirst(x => x.BillerId == _billerDetail.Id);
        }


        private async Task<Settlement> SaveSettlement(NotificationRequest request)
        {

            string ercasCollectId = GetErcasCollectId(request);

            _billerDetail = _billerRepository.FindFirst(x => x.ReferenceKey == ercasCollectId);

            var checkSettlement = _settlementRepository.FindFirst(x => x.ReferenceID == request.SessionID && x.BillerId == _billerDetail.Id);

            if (checkSettlement != null)

                return null;

            Settlement settlement = GetSettlement(request);

            if (settlement.TransactionNumber == null)

                settlement.TransactionNumber = request.SessionID;

            var savedSettlement = await _settlementRepository.Add(settlement);

            await _settlementRepository.CommitAsync();

            return savedSettlement;

        }

        private Settlement GetSettlement(NotificationRequest request)
        {
            return new Settlement()
            {
                Amount = Convert.ToDecimal(GetAmount(request)),

                BillerId = _billerDetail.Id,

                SourceBank = request.SourceBankCode,

                DestinationBank = request.DestinationBankCode,

                ApprovedDate = JsonXmlObjectConverter.ConvertTimestampToDateTime(request.TransactionApprovalDate),

                IsSuccess = true,

                PaidBy = GetPayerName(request),

                PayerPhone = GetPayerPhone(request),

                ReferenceID = request.SessionID,

                TransactionNumber = GetTransactionKey(request),

                PaymentChannel = PaymentChannels.Nibss,

                TransactionType = GetTransactionType(request)

            };
        }

        private TypesOfTransaction GetTransactionType(NotificationRequest request)
        {
           TypesOfTransaction transactionType = 0;

            if (request.ProductName.Equals("Remittance"))
            
                transactionType = TypesOfTransaction.Remittance;
            

            if (request.ProductName.Equals("Invoice"))
            
                transactionType = TypesOfTransaction.Remittance;
            

            if (request.ProductName.Equals("Non-Tax"))
            
                transactionType = TypesOfTransaction.Remittance;
            

            if (request.ProductName.Equals("Tax"))
            
                transactionType = TypesOfTransaction.Remittance;
            

            return transactionType;
        }

        private string GetTransactionKey(NotificationRequest request)
        {
            var transactionId = string.Empty;

            for (int i = 0; i < request.Param.Count; i++)
            {
                if (request.Param[i].Key.Equals(_nameConstant.Remittance))
                {
                    transactionId = request.Param[i].Value;
                }

                if (request.Param[i].Key.Equals(_nameConstant.Invoice))
                {
                    transactionId = request.Param[i].Value;
                }
            }

            return transactionId;
        }

        private string GetPayerName(NotificationRequest request)
        {
            var payerName = string.Empty;

            for (int i = 0; i < request.Param.Count; i++)
            {
                if (request.Param[i].Key.Equals(_nameConstant.PayerName))
                {
                    payerName = request.Param[i].Value;
                }
            }

            return payerName;
        }

        private string GetPayerPhone(NotificationRequest request)
        {
            var phone = string.Empty;

            for (int i = 0; i < request.Param.Count; i++)
            {
                if (request.Param[i].Key.Equals(_nameConstant.PhoneNumber))
                {
                    phone = request.Param[i].Value;
                }
            }

            return phone;
        }

        private string GetAmount(NotificationRequest request)
        {
            var amount = string.Empty;

            for (int i = 0; i < request.Param.Count; i++)
            {
                if (request.Param[i].Key.Equals(_nameConstant.Amount))
                {
                    amount = request.Param[i].Value;
                }
            }

            return amount;
        }

        private string GetErcasCollectId(NotificationRequest request)
        {
            var ercasCollectId = string.Empty;

            for (int i = 0; i < request.Param.Count; i++)
            {
                if (request.Param[i].Key.Equals(_nameConstant.ercasCollectId))
                {
                    ercasCollectId = request.Param[i].Value;
                }
            }

            return ercasCollectId;
        }


    }
}
