using ErcasCollect.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models
{
    public class CategoryTwoService : BaseEntity
    {
        [Column(TypeName = "nvarchar(32)")]

        public string ReferenceKey { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]

        public decimal Amount { get; set; }

        public int? BillerId { get; set; }

        public Biller Biller { get; set; }

        public int? LevelOneId { get; set; }

        public LevelOne LevelOne { get; set; }

        public int? CategoryOneServiceId { get; set; }

        public CategoryOneService CategoryOneService { get; set; }

        public bool IsAmountFixed { get; set; }
    }
}
