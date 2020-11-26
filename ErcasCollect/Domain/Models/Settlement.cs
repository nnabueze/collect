using System;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class Settlement:TransactionBaseEntity
    {
        [Column(TypeName = "nvarchar(32)")]
        public string BankId { get; set; }
        public Bank Bank { get; set; } 
        public string BillerId { get; set; }
        public Biller Biller{ get; set; }
        public int PaymentChannelId { get; set; }
        public PaymentChannel PaymentChannel{ get; set; }

        public int TransactionTypeId { get; set; }
        public TransactionType  TransactionType{ get; set; }
       [Column(TypeName = "nvarchar(32)")]
        public string PaidBy { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string PayerPhone { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string ReferenceID { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string TransactionID { get; set; }
        public Status Status { get; set; }
        public string StatusId { get; set; }



    }
}
