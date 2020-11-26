using System;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class User:BaseEntity
    {
        public int SsoId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string BillerId { get; set; }
        public Biller Biller { get; set; }
        public string LevelTwoId { get; set; }
        public LevelTwo LevelTwo { get; set; }

        public string LevelOneId { get; set; }
        public LevelOne LevelOne { get; set; }

        public string StatusId { get; set; }
        public Status Status { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CollectionLimit { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CashAtHand { get; set; }
        


    }
}
