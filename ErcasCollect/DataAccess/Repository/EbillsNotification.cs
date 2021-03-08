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

        private readonly IGenericRepository<Batch> _batchRepository;

        private Biller _billerDetail = null;

        public EbillsNotification(IOptions<NameConstant> nameConstant, IGenericRepository<Biller> billerRepository, IGenericRepository<BillerValidation> billerValidationRepository,

            IGenericRepository<BillerEbillsProduct> billerEbillsProductRepository, IGenericRepository<CloseBatchTransaction> closeBatchTransactionRepository,

            IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<LevelTwo> levelTwoRepository, IOptions<ResponseCode> responseCode, IGenericRepository<Settlement> settlementRepository,

            IGenericRepository<LevelDisplayName> levelDisplayNameRepository, IGenericRepository<Batch> batchRepository)
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

            _batchRepository = batchRepository;
        }

        public async Task<NotificationResponse> Push(NotificationRequest request)
        {
            var saveSettlement = await SaveSettlement(request);

            if (saveSettlement == null)

                return NotificationFailedResponse(request, _nameConstant.DuplicateTransaction);

            var savedClosedId = await SaveClosedBatchTransaction(request, saveSettlement.TransactionNumber);

            await UpdateBatchPaymentProcessor(savedClosedId);

            return NotificationSuccessResponse(request);
        }

        private async Task UpdateBatchPaymentProcessor(int closedBatchId)
        {
            var batches = _batchRepository.Find(x => x.CloseBatchTransactionId == closedBatchId);

            if(batches != null)
            {
                foreach (var item in batches)
                {
                    item.PaymentProcessorId = 2;

                    _batchRepository.Update(item);
                }

                await _batchRepository.CommitAsync();
            }
        }

        private NotificationResponse NotificationSuccessResponse(NotificationRequest request)
        {
            var notificationResponse = new NotificationResponse()
            {
                BillerID = request.BillerID,

                ResponseCode = _responseCode.NibssSuccessCode,

                ResponseMessage = _nameConstant.TransactionSuccessful,

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

        private async Task<int> SaveClosedBatchTransaction(NotificationRequest request, string transactionId)
        {
            var closeBatchTransaction = _closeBatchTransactionRepository.FindFirst(x => x.ReferenceKey == transactionId && x.BillerId == _billerDetail.Id);

            if(closeBatchTransaction != null)
            {
                closeBatchTransaction.IsPaid = true;

                closeBatchTransaction.ModifiedDate = DateTime.UtcNow;

                closeBatchTransaction.PaymentChannelId = 2;

                _closeBatchTransactionRepository.Update(closeBatchTransaction);

                await _closeBatchTransactionRepository.CommitAsync();

                return closeBatchTransaction.Id;
            }
            else
            {
                var savedBatchTransaction = new CloseBatchTransaction()
                {
                    BillerId = _billerDetail.Id,

                    IsPaid = true,

                    LevelOneId = GetLevelOneId(request),

                    LevelTwoId = GetLevelTwoId(request),

                    PaymentChannelId = 2,

                    TotalAmount = Convert.ToDecimal(GetAmount(request)),

                    ReferenceKey = request.SessionID
                };

                var savedClosed = await _closeBatchTransactionRepository.Add(savedBatchTransaction);

                await _closeBatchTransactionRepository.CommitAsync();

                return savedClosed.Id;
            }
        }

        private int GetLevelOneId(NotificationRequest request)
        {
            string levelOneStingId = string.Empty;

            var displayName = GetBillerDisplayname();

            if (displayName != null)
            {
                for (int i = 0; i < request.Param.Count; i++)
                {
                    if (request.Param[i].Key.Equals(displayName.LevelOneDisplayName + _nameConstant.LevelKeyIdentify))
                    {
                        levelOneStingId = request.Param[i].Value;
                    }
                }
            }

            int levelOneId;

            if (! string.IsNullOrEmpty(levelOneStingId))
            {
                levelOneId = _levelOneRepository.FindFirst(x => x.ReferenceKey == levelOneStingId).Id;
            }
            else
            {
                levelOneId = _levelOneRepository.FindFirst(x => x.BillerId == _billerDetail.Id).Id;
            }

            return levelOneId;
        }

        private int GetLevelTwoId(NotificationRequest request)
        {
            string levelTwoStingId = string.Empty;

            var displayName = GetBillerDisplayname();

            if (displayName != null)
            {
                for (int i = 0; i < request.Param.Count; i++)
                {
                    if (request.Param[i].Key.Equals(displayName.LevelTwoDisplayName + _nameConstant.LevelKeyIdentify))
                    {
                        levelTwoStingId = request.Param[i].Value;
                    }
                }
            }

            int levelTwoId;

            if (! string.IsNullOrEmpty(levelTwoStingId))
            {
                levelTwoId = _levelTwoRepository.FindFirst(x => x.ReferenceKey == levelTwoStingId).Id;
            }
            else
            {
                levelTwoId = _levelTwoRepository.FindFirst(x => x.BillerId == _billerDetail.Id).Id;
            }

            return levelTwoId;
        }

        private LevelDisplayName GetBillerDisplayname()
        {
            var displyName = _levelDisplayNameRepository.FindFirst(x => x.BillerId == _billerDetail.Id);

            if (displyName == null)
            {
                return null;
            }

            return displyName;
        }


        private async Task<Settlement> SaveSettlement(NotificationRequest request)
        {

            string remittance = GetTransactionKey(request);

            string billerAbraviation = GetBillerAbbreviation(remittance);

            _billerDetail = _billerRepository.FindFirst(x => x.Abbreviation == billerAbraviation);

            if (_billerDetail == null)

                return null;

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


        private string GetBillerAbbreviation(string remittanceId)
        {
            var splitedRemittance = remittanceId.Split("-");

            return splitedRemittance[0];
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

                PaymentChannelId = 2,

                CreatedDate = DateTime.UtcNow,

                TransactionTypeId = GetTransactionType(request)

            };
        }

        private int GetTransactionType(NotificationRequest request)
        {

            if (request.ProductName.Equals(_nameConstant.Remittance))
            
                return  2;
            

            if (request.ProductName.Equals(_nameConstant.Invoice))
            
                return 4;
            

            if (request.ProductName.Equals(_nameConstant.NonTax))
            
                return 5;
            

            if (request.ProductName.Equals(_nameConstant.Tax))
            
                return 3;

            return 0;
            
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
