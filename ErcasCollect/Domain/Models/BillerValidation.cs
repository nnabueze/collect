using ErcasCollect.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models
{
    public class BillerValidation : BaseEntity
    {

        public int? BillerId { get; set; }

        public Biller Biller { get; set; }

        public int? BillerEbillsProductId { get; set; }

        public BillerEbillsProduct BillerEbillsProduct { get; set; }

        public string ValidationName { get; set; }

        public int VaidationStep { get; set; }
    }
}
