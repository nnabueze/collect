using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Dto.CollectionDto
{
    public class PosInvoiceDto
    {
        public string PosId { get; set; }

        public string UserId { get; set; }

        public string BillerId { get; set; }

        public string LevelOneId { get; set; }

        public string LevelTwoId { get; set; }

        public string TotalAmount { get; set; }

        public List<InvoiceDetail> Invoices { get; set; }
    }

    public class InvoiceDetail
    {
        public string PayerName { get; set; }

        public string Amount { get; set; }

        public string PayerPhone { get; set; }

        public string CategoryTwoId { get; set; }
    }
}
