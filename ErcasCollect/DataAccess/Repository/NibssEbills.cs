using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Domain.Models.Nibss;
using ErcasCollect.Helpers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ErcasCollect.DataAccess.Repository
{
    public class NibssEbills : INibssEbills
    {
        private readonly NameConstant _nameConstant;

        private readonly IGenericRepository<Biller> _billerRepository;

        private readonly IGenericRepository<BillerValidation> _billerValidationRepository;

        private readonly IGenericRepository<BillerEbillsProduct> _billerEbillsProductRepository;

        private readonly ITransactionRepository _transactionRepository;

        public NibssEbills(IOptions<NameConstant> nameConstant, IGenericRepository<Biller> billerRepository, IGenericRepository<BillerValidation> billerValidationRepository, IGenericRepository<BillerEbillsProduct> billerEbillsProductRepository)
        {
            _nameConstant = nameConstant.Value;

            _billerRepository = billerRepository;

            _billerValidationRepository = billerValidationRepository;

            _billerEbillsProductRepository = billerEbillsProductRepository;
        }

        public async Task<NotificationResponse> Notification(string request)
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResponse> Validation(string stringRequest)
        {            


            var request = JsonXmlObjectConverter.XmlToObject<ValidationRequest>(stringRequest);


            switch (request.ProductName)
            {
                case "Remittance":
                    Remittance(request);
                    break;
                default:
                    return null;
            }

            return null;
        }

        public void Remittance(ValidationRequest request)
        {
            var remittanceId = GetRemittanceParameter(request);

            //var transaction 
            
        }

        private string GetRemittanceParameter(ValidationRequest request)
        {
            var referenceId = string.Empty;

            var remittanceId = string.Empty;

            for (int i = 0; i < request.Param.Count; i++)
            {
                if (request.Param[i].Key.Equals(_nameConstant.ercasReferenceId))
                {
                    referenceId = request.Param[i].Value;
                }
            }

            var billerId = _billerRepository.FindFirst(x => x.ReferenceKey == referenceId).Id;

            var productId = _billerEbillsProductRepository.FindFirst(x => x.BillerId == billerId && x.ProductName == _nameConstant.Remittance).Id;

            var validationParameter = _billerValidationRepository.FindFirst(x => x.BillerId == billerId && x.BillerEbillsProductId == productId).ValidationName;

            for (int i = 0; i < request.Param.Count; i++)
            {
                if (request.Param[i].Key.Equals(validationParameter))
                {
                    remittanceId = request.Param[i].Value;
                }
            }

            return remittanceId;
        }
    }
}
