using System;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class Settlement:TransactionBaseEntity
    {
        public int? BankId { get; set; }

        public Bank Bank { get; set; } 

        public int? BillerId { get; set; }

        public Biller Biller{ get; set; }

        public int? PaymentChannelId { get; set; }

        public PaymentChannel PaymentChannel{ get; set; }

        public int? TransactionTypeId { get; set; }

        public TransactionType  TransactionType{ get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string PaidBy { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string PayerPhone { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string ReferenceID { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string TransactionNumber { get; set; }

        public string TransactionStatus { get; set; }

        public int StatusCode { get; set; }



    }
}
