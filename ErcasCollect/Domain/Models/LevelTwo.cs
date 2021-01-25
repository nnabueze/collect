using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
   //Can be  
    public class LevelTwo:BaseEntity
    {
      

        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }

        public int? BillerId { get; set; }
        public Biller Biller { get; set; }

        public int? LevelOneId { get; set; }
        public LevelOne LevelOne{ get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Longitude { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Latitude { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }

        public int? PosId { get; set; }

        public Pos Pos { get; set; }

    }
}
