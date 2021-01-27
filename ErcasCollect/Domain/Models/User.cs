using System;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class User:BaseEntity
    {
        public int SsoId { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public int BillerId { get; set; }
        public Biller Biller { get; set; }
        public int? LevelTwoId { get; set; }
        public LevelTwo LevelTwo { get; set; }

        public int? LevelOneId { get; set; }
        public LevelOne LevelOne { get; set; }

        public int StatusCode { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CollectionLimit { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CashAtHand { get; set; }
        public string Name { get; set; }



    }
}
