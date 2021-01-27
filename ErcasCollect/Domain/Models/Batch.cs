using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;
using ErcasCollect.Helpers.EnumClasses;

namespace ErcasCollect.Domain.Models
{
    public class Batch : BaseEntity
    {
        public string ReferenceKey { get; set; }

        public int ItemCount { get; set; }
        
        public string OfflineBatchId { get; set; }
   
        [Column(TypeName = "decimal(18,2)")]

        public decimal TotalAmount { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int? BillerId { get; set; }

        public Biller  Biller { get; set; }

        public int? PosId { get; set; }

        public Pos Pos { get; set; }

        public bool IsSuccess { get; set; }

        public TypesOfTransaction TransactionType { get; set; }

        public PaymentChannels PaymentChannel { get; set; }

        public bool IsBatchClosed { get; set; }

        public string ClosedRemiteId { get; set; }


    }
}
