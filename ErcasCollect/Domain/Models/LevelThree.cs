﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    // Service or Subheads in IGR 
    public class LevelThree:BaseEntity
    {
        
        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal  Amount { get; set; }
        public int? BillerId { get; set; }
        public Biller Biller { get; set; }
        public int? LevelOneId { get; set; }
        public LevelOne LevelOne { get; set; }
        public bool IsAmountFixed { get; set; }

    }
}
