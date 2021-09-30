using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Queries.Dto
{
    public class ReadFlexTransactionDto
    {
        public decimal Amount { get; set; }

        public string PayerName { get; set; }

        public string PayerPhone { get; set; }

        public string ReferenceKey { get; set; }

        public bool IsSuccess { get; set; }

        public string ProcessedBy { get; set; }

        public string DateProcessed { get; set; }
    }
}
