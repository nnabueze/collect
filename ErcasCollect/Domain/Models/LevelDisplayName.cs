using ErcasCollect.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models
{
    public class LevelDisplayName : BaseEntity
    {
        public int? BillerId { get; set; }

        public Biller Biller { get; set; }

        public string LevelOneDisplayName { get; set; }

        public string LevelTwoDisplayName { get; set; }

        public string CategoryOneDisplayName { get; set; }

        public string CategoryTwoDisplayName { get; set; }
    }
}
