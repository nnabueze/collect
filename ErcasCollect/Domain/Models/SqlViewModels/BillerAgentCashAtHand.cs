using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models.SqlViewModels
{
    public class BillerAgentCashAtHand
    {
        public int BillerId { get; set; }

        public Biller Biller { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public decimal TotalCashAtHand { get; set; }
    }
}
