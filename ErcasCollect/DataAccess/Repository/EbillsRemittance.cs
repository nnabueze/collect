using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Domain.Models.Nibss;
using ErcasCollect.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ErcasCollect.Domain.Models.Nibss.ValidationResponse;

namespace ErcasCollect.DataAccess.Repository
{
    public class EbillsRemittance : IEbillsRemittance
    {

        private readonly NameConstant _nameConstant;

        private readonly IGenericRepository<Biller> _billerRepository;

        private readonly IGenericRepository<BillerValidation> _billerValidationRepository;

        private readonly IGenericRepository<BillerEbillsProduct> _billerEbillsProductRepository;

        private readonly IGenericRepository<CloseBatchTransaction> _closeBatchTransactionRepository;

        private readonly IGenericRepository<LevelDisplayName> _levelDisplayNameRepository;

        private readonly IGenericRepository<LevelOne> _levelOneRepository;

        private readonly IGenericRepository<LevelTwo> _levelTwoRepository;

        private readonly IGenericRepository<User> _userRepository;

        private Biller _billerDetail = null;

        private string _remittanceStringId;

        private string _amount;

        private bool _isRemittance;

        private readonly ResponseCode _responseCode;

        public EbillsRemittance(IOptions<NameConstant> nameConstant, IGenericRepository<Biller> billerRepository,

            IGenericRepository<BillerValidation> billerValidationRepository, IGenericRepository<BillerEbillsProduct> billerEbillsProductRepository,

            IGenericRepository<LevelDisplayName> levelDisplayNameRepository, IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<LevelTwo> levelTwoRepository,

            IGenericRepository<User> userRepository, IOptions<ResponseCode> responseCode, IGenericRepository<CloseBatchTransaction> closeBatchTransactionRepository)
        {
            _nameConstant = nameConstant.Value;

            _billerRepository = billerRepository;

            _billerValidationRepository = billerValidationRepository;

            _billerEbillsProductRepository = billerEbillsProductRepository;

            _levelDisplayNameRepository = levelDisplayNameRepository;

            _levelOneRepository = levelOneRepository;

            _levelTwoRepository = levelTwoRepository;

            _userRepository = userRepository;

            _responseCode = responseCode.Value;

            _closeBatchTransactionRepository = closeBatchTransactionRepository;
        }

        public ValidationResponse Detail(ValidationRequest request)
        {
            var remittanceDetails = GetRemittanceDetails(request);

            if(remittanceDetails == null)

                return RemittanceFailedResponse(request, _nameConstant.UsedTransactionNumber);

            var remittanceField = RemittanceField(remittanceDetails);

            if(_isRemittance)

                return RemittanceSuccessResponse(request, remittanceField);

            return RemittanceFailedResponse(request, _nameConstant.UsedTransactionNumber);

        }

        private ValidationResponse RemittanceSuccessResponse(ValidationRequest request, List<ParamData> parameterLists)
        {
            var validationResponse = new ValidationResponse()
            {
                BillerID = request.BillerID,

                NextStep = "0",

                ResponseCode = _responseCode.NibssSuccessCode,

                Params = parameterLists,

                PaymentDetail = PaymentDetail(_amount)
            };

            return validationResponse;
        }


        public ValidationResponse RemittanceFailedResponse(ValidationRequest request, string message)
        {
            var validationResponse = new ValidationResponse()
            {
                BillerID = request.BillerID,

                NextStep = "0",

                ResponseCode = _responseCode.NibssFailedCode,

                ResponseMessage = message
            };

            return validationResponse;
        }

        public PaymentDetail PaymentDetail(string amount)
        {
            var paymentDetails = new PaymentDetail()
            {
                Amount = amount
            };

            return paymentDetails;
        }

        private List<ParamData> RemittanceField(CloseBatchTransaction closeBatchTransaction)
        {
            Dictionary<string, string> remittanceField = new Dictionary<string, string>();

            var user = UserDetail((int)closeBatchTransaction.UserId);

            var levelOne = LevelOneDetail((int)closeBatchTransaction.LevelOneId);

            var levelTwo = LevelTwoDetail((int)closeBatchTransaction.LevelTwoId);

            var billerDisplayName = BillerDisplayName(_billerDetail.Id);

            remittanceField.Add(billerDisplayName.LevelOneDisplayName, levelOne.Name);

            remittanceField.Add(billerDisplayName.LevelTwoDisplayName, levelTwo.Name);

            remittanceField.Add(billerDisplayName.LevelTwoDisplayName + _nameConstant.LevelKeyIdentify, levelTwo.ReferenceKey);

            remittanceField.Add(billerDisplayName.LevelOneDisplayName + _nameConstant.LevelKeyIdentify, levelOne.ReferenceKey);

            remittanceField.Add(_nameConstant.Remittance, _remittanceStringId);

            remittanceField.Add(_nameConstant.Amount, closeBatchTransaction.TotalAmount.ToString());

            remittanceField.Add(_nameConstant.PhoneNumber, user.PhoneNumber);

            //remittanceField.Add(_nameConstant.ercasCollectId, _billerDetail.ReferenceKey);

            //remittanceField.Add(_nameConstant.ercasGatewayId, _billerDetail.GatewayUsername);

            return ParameterList(remittanceField);
        }

        private List<ParamData> ParameterList(Dictionary<string, string> keyValuePairs)
        {
            List<ParamData> remittanceList = new List<ParamData>();

            foreach (var item in keyValuePairs)
            {
                var parameter = new ParamData()
                {
                    Key = item.Key,

                    Value = item.Value
                };

                remittanceList.Add(parameter);
            }

            return remittanceList;
        }

        private CloseBatchTransaction GetRemittanceDetails(ValidationRequest request)
        {

            string remittnaceId = GetRemittanceId(request);

            if (remittnaceId == null)

                return null;

            var billerAbbreviation = GetBillerAbbreviation(remittnaceId);

            _billerDetail = _billerRepository.FindFirst(x => x.Abbreviation == billerAbbreviation);

            if (_billerDetail == null)

                return null;

            return GetCloseBatchTrasnaction();
        }

        private string GetBillerAbbreviation(string remittanceId)
        {
            var splitedRemittance = remittanceId.Split("-");

            return splitedRemittance[0];
        }

        private LevelTwo LevelTwoDetail(int levelTwoId)
        {
            return _levelTwoRepository.FindFirst(x => x.Id == levelTwoId);
        }

        private LevelOne LevelOneDetail(int levelOneId)
        {
            return _levelOneRepository.FindFirst(x => x.Id == levelOneId);
        }

        private LevelDisplayName BillerDisplayName(int billerId)
        {
            return _levelDisplayNameRepository.FindFirst(x => x.BillerId == billerId);
        }

        private User UserDetail(int userId)
        {
            return _userRepository.FindFirst(x => x.Id == userId);
        }


        private CloseBatchTransaction GetCloseBatchTrasnaction()
        {
            var closeBatch = _closeBatchTransactionRepository.FindFirst(x => x.ReferenceKey == _remittanceStringId && x.BillerId == _billerDetail.Id && x.IsPaid == false);

            if (closeBatch != null)
            {
                _amount = closeBatch.TotalAmount.ToString();

                _isRemittance = true;

                return closeBatch;
            }

            _isRemittance = false;

            return closeBatch;
        }

        private string GetRemittanceId(ValidationRequest request)
        {

            for (int i = 0; i < request.Param.Count; i++)
            {
                if (request.Param[i].Key.Equals(_nameConstant.Remittance))
                {
                    _remittanceStringId = request.Param[i].Value;
                }
            }

            return _remittanceStringId;
        }
    }
}
