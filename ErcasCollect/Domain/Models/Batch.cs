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

        public int? LevelOneId { get; set; }

        public LevelOne LevelOne { get; set; }

        public int? LevelTwoId { get; set; }

        public LevelTwo LevelTwo { get; set; }

        public bool IsSuccess { get; set; }

        public int? TransactionTypeId { get; set; }

        public TransactionType TransactionType { get; set; }

        public int? PaymentChannelId { get; set; }

        public PaymentChannel PaymentChannel { get; set; }

        public bool IsBatchClosed { get; set; }

        public DateTime? OfflineCreatedDate { get; set; }

        public int? CloseBatchTransactionId { get; set; }

        public CloseBatchTransaction CloseBatchTransaction { get; set; }


    }
}
