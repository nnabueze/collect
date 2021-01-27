using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Dto.CollectionDto
{
    public class PosCollectionDto
    {
        public string BillerId { get; set; }

        public string PosId { get; set; }

        public string UserId { get; set; }

        public string LevelOneId { get; set; }

        public string LevelTwoId { get; set; }

        public string OfflineBatchId { get; set; }

        public string TotalAmount { get; set; }
        
        public string ItemCount { get; set; }

        public List<Item> TransactionItems { get; set; }
    }

    public class Item
    {
        public string Amount { get; set; }

        public string CategoryTwoId { get; set; }

        public string PayerName { get; set; }

        public string PayerPhone { get; set; }
    }
}
