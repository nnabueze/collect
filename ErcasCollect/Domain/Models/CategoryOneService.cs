using ErcasCollect.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models
{
    public class CategoryOneService : BaseEntity
    {
        [Column(TypeName = "nvarchar(32)")]

        public string ReferenceKey { get; set; }

        public int? BillerId { get; set; }

        public Biller Biller { get; set; }

        public string Name { get; set; }

        public int? LevelOneId { get; set; }

        public LevelOne LevelOne { get; set; }

        public ICollection<CategoryTwoService> CategoryTwoService { get; set; }
    }
}
