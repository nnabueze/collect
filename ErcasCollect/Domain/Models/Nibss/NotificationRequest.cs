using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models.Nibss
{
    public class NotificationRequest
    {
        public string SessionID { get; set; }

        public string SourceBankCode { get; set; }

        public string ChannelCode { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAccountNumber { get; set; }

        public string BillerID { get; set; }

        public string BillerName { get; set; }

        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public string Amount { get; set; }

        public string TotalAmount { get; set; }

        public string Fee { get; set; }

        public string TransactionFeeBearer { get; set; }

        public string SplitType { get; set; }

        public string DestinationBankCode { get; set; }

        public string Narration { get; set; }

        public string PaymentReference { get; set; }

        public string TransactionInitiatedDate { get; set; }

        public string TransactionApprovalDate { get; set; }

        public List<ParamDetail> Param { get; set; }

        public class ParamDetail
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}
