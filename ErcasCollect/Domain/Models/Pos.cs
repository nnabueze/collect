using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class Pos:BaseEntity
    {
        public string OSId { get; set; }
        public OS OS{ get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Version { get; set; }
        public string StatusId { get; set; }
        public Status Status { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string BillerId{ get; set; }
        public Biller Biller { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string LevelOneId { get; set; }
        public LevelOne LevelOne{ get; set; }

        public string Activationpin { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string LevelTwoId{ get; set; }
        public LevelTwo LevelTwo { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string UserId { get; set; }
        public User User { get; set; }



    }
}
