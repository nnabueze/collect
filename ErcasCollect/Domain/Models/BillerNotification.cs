using ErcasCollect.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models
{
    public class BillerNotification : BaseEntity
    {

        public int? BillerId { get; set; }

        public Biller Biller { get; set; }

        public int? BillerEbillsProductId { get; set; }

        public BillerEbillsProduct BillerEbillsProduct { get; set; }

        public string NotificationName { get; set; }
    }
}
