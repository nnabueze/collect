using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Queries.Dto
{
    public class MonthlyTopPerformingBillerDto
    {
        public string BillerName { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
