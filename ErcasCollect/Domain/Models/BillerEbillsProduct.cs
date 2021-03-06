using ErcasCollect.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models
{
    public class BillerEbillsProduct : BaseEntity
    {
        public string ReferenceKey { get; set; }

        public int? EbillsProductId { get; set; }

        public EbillsProduct EbillsProduct { get; set; }

        public int? BillerId { get; set; }

        public Biller Biller { get; set; }
    }
}
