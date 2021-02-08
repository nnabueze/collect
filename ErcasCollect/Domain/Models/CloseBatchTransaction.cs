using ErcasCollect.Domain.BaseEntities;
using ErcasCollect.Helpers.EnumClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models
{
    public class CloseBatchTransaction : BaseEntity
    {
        public string ReferenceKey { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }

        public int? LevelOneId { get; set; }

        public LevelOne LevelOne { get; set; }

        public int? LevelTwoId { get; set; }

        public LevelTwo LevelTwo { get; set; }

        public decimal TotalAmount { get; set; }

        public bool IsPaid { get; set; }

        public int? BillerId { get; set; }

        public Biller Biller { get; set; }

        public int? PaymentChannelId { get; set; }

        public PaymentChannel PaymentChannel { get; set; }

        public int? TransactionTypeId { get; set; }

        public TransactionType TransactionType { get; set; }
    }
}
