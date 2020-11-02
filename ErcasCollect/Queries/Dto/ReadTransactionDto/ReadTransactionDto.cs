using System;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Queries.Dto.ReadTransactionDto
{
    public class ReadTransactionDto
    {
      

    
        public Status Status { get; set; }
     
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }

        public Pos Pos { get; set; }
        public string PayerName { get; set; }
        public string PayerPhone { get; set; }
   
        public User Agent { get; set; }
        public string SessionId { get; set; }
        public string OfflineSessionId { get; set; }
  
        public Biller Biller { get; set; }

        public string BatchId { get; set; }
        public string OfflineBatchId { get; set; }
    
        public TransactionType TransactionType { get; set; }

        public PaymentChannel PaymentChannel { get; set; }
    }
}
