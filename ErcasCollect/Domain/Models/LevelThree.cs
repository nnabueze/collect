using System;
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
        [Column(TypeName = "nvarchar(32)")]
        public string BillerId { get; set; }
        public Biller Biller { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public int LevelOneId { get; set; }
        public LevelOne LevelOne { get; set; }
        public int LevelTwoId { get; set; }
        public LevelTwo  LevelTwo{ get; set; }
        public bool IsAmountFixed { get; set; }


    }
}
