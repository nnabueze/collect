using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;
using ErcasCollect.Helpers.EnumClasses;

namespace ErcasCollect.Domain.Models
{
    public class Transaction : BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]

        public decimal Amount { get; set; }

        public string PayerName { get; set; }

        public string PayerPhone{ get; set; }

        public string OfflineBatchId { get; set; }

        public int? BatchId { get; set; }

        public Batch Batch { get; set; }

        public int? PaymentChannelId { get; set; }

        public PaymentChannel PaymentChannel { get; set; }

        public string ReferenceKey { get; set; }        

        public int? CategoryTwoServiceId { get; set; }

        public CategoryTwoService CategoryTwoService { get; set; }
    }
}
