using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class LevelOne:BaseEntity
    {
     
        [Column(TypeName = "nvarchar(32)")]

        public string Name { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string Description { get; set; }

        public int BillerId { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string ReferenceKey { get; set; }

        public Biller Biller { get; set; }


        [Column(TypeName = "decimal(18,6)")]

        public decimal FundsweepPercentage { get; set; }

        public ICollection<LevelTwo> LevelTwo { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Pos> Poses { get; set; }

        public ICollection<CategoryOneService> CategoryOneService { get; set; }

        public ICollection<CategoryTwoService> CategoryTwoService { get; set; }
    }
}
