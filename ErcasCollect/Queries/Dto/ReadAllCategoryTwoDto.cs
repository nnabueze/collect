using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Queries.Dto
{
    public class ReadAllCategoryTwoDto
    {
        public string ReferenceKey { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public bool IsAmountFixed { get; set; }
    }
}
