using System;
using System.Collections.Generic;

namespace ErcasCollect.Responses
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

        public int BillerID { get; set; }

        public string BillerName { get; set; }

        public string RemitttanceID { get; set; }

        public string ProductName { get; set; }

        public string Amount { get; set; }
        public List<Param> Param { get; set; }
    }


    public class Param
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
