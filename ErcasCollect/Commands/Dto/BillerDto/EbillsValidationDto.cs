using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Dto.BillerDto
{
    public class EbillsValidationDto
    {
        public string BillerId { get; set; }

        public string BillerProductId { get; set; }

        public string ValidationField { get; set; }

        public int ValidationStep { get; set; }
    }

    public class PaymentDetail
    {
        public string Amount { get; set; }
    }

    public class EbillsBillerValidationDto
    {
        public string ValidationName { get; set; }

        public int VaidationStep { get; set; }
    }


}
