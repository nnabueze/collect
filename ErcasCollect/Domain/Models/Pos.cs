using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class Pos:BaseEntity
    {
        public int OSId { get; set; }
        public OS OS{ get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Version { get; set; }
        public int StatusCode { get; set; }

        public int? BillerId{ get; set; }
        public Biller Biller { get; set; }
        public int? LevelOneId { get; set; }
        public LevelOne LevelOne{ get; set; }

        public string Activationpin { get; set; }
        public int? LevelTwoId{ get; set; }
        public LevelTwo LevelTwo { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }



    }
}
