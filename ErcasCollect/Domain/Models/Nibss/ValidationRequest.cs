using ErcasCollect.Commands.Dto.BillerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ErcasCollect.Domain.Models.Nibss
{
    
    public class ValidationRequest
    {
        
        public string SourceBankCode { get; set; }

        
        public string SourceBankName { get; set; }

        
        public string InstitutionCode { get; set; }

        
        public string ChannelCode { get; set; }

       
        public string Step { get; set; }

        
        public string StepCount { get; set; }

        
        public string CustomerName { get; set; }

        
        public string CustomerAccountNumber { get; set; }

        public string BillerID { get; set; }

        public string BillerName { get; set; }

        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public string Amount { get; set; }

        public List<Detail> Param { get; set; }


    }

    public class Detail
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }

}
