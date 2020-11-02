using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class Transaction:BaseEntity
    {
        [Column(TypeName = "nvarchar(32)")]
       
        public string StatusId { get; set; }
        public Status Status { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        public string PosId { get; set; }
        public Pos Pos { get; set; }
        public string PayerName { get; set; }
        public string PayerPhone{ get; set; }
        public string AgentId { get; set; }
        public User Agent { get; set; }
        public string SessionId { get; set; }
        public string OfflineSessionId { get; set; }
        public string BillerId { get; set; }
        public Biller Biller { get; set; }
   
        public string BatchId { get; set; }
        public string OfflineBatchId { get; set; }
        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }
        public int PaymentChannelId { get; set; }
        public PaymentChannel PaymentChannel{ get; set; }




    }
}
