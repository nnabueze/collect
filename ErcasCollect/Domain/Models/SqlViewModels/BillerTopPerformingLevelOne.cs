using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models.SqlViewModels
{
    public class BillerTopPerformingLevelOne
    {
        public int BillerId { get; set; }

        public Biller Biller { get; set; }

        public int LevelOneId { get; set; }

        public LevelOne levelOne { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
