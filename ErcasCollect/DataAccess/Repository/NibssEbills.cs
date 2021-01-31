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
        private readonly IEbillsRemittance _ebillsRemittance;

        public NibssEbills(IEbillsRemittance ebillsRemittance)
        {
            _ebillsRemittance = ebillsRemittance;
        }

        public async Task<NotificationResponse> Notification(string request)
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResponse> Validation(ValidationRequest request)
        {            


            //var request = JsonXmlObjectConverter.XmlToObject<ValidationRequest>(stringRequest);


            switch (request.ProductName)
            {
                case "Remittance":

                    return Remittance(request);

                default:

                    return null;
            }

            return null;
        }

        public ValidationResponse Remittance(ValidationRequest request)
        {
            return  _ebillsRemittance.Detail(request);            
        }




    }
}
