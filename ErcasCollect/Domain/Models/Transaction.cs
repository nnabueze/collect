﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class Transaction:BaseEntity
    {
        [Column(TypeName = "nvarchar(32)")]
        public string BatchId { get; set; }
        public string StatusId { get; set; }
        public Status Status { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        public string PosId { get; set; }
        public Pos Pos { get; set; }
        public string PayerName { get; set; }
        public string PayerPhone{ get; set; }
        public User Agent { get; set; }

    }
}
