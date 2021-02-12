using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Queries.Dto
{
    public class ReadAllBatchTransactionDto
    {
        public string ReferenceKey { get; set; }

        public int ItemCount { get; set; }

        public string OfflineBatchId { get; set; }

        public string TotalAmount { get; set; }

        public string UserName { get; set; }

        public string BillerName { get; set; }

        public string LevelOneName { get; set; }

        public string LevelTwoName { get; set; }

        public bool IsSuccess { get; set; }

        public string TransactionType { get; set; }

        public string PaymentChannel { get; set; }

        public bool IsBatchClosed { get; set; }

        public string OfflineCreatedDate { get; set; }
    }

    public class ReadListTransactionDto
    {
        public string Amount { get; set; }

        public string PayerName { get; set; }

        public string PayerPhone { get; set; }

        public string BatchReferenceKey { get; set; }

        public string ReferenceKey { get; set; }

        public string CategoryTwoServiceName { get; set; }
    }
}
