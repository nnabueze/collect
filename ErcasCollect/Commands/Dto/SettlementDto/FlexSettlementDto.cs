using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Dto.SettlementDto
{
    public class FlexSettlementDto
    {
        public string BillerId { get; set; }        

        public string PayerName { get; set; }

        public string PayerPhone { get; set; }

        public string ReferenceNumber { get; set; }

        public string TransactionNumber { get; set; }

        public decimal TotalAmount { get; set; }

        public string TransactionStatus { get; set; }

        public int StatusCode { get; set; }

        public List<TransactionItem> transactionItems { get; set; }
    }

    public class TransactionItem
    {
        public int LevelThreeId { get; set; }

        public int LevelOneId { get; set; }

        public int LevelTwoId { get; set; }

        public string ItemName { get; set; }

        public decimal Amount { get; set; }
    }
}
