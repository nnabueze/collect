using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models.SqlViewModels
{
    public class MonthlyTopPerformingBillers
    {
        public string BillerName { get; set; }

        public int BillerId { get; set; }

        public Biller Biller { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
