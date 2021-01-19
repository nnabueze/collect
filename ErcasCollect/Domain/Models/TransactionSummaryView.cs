using System;
namespace ErcasCollect.Domain.Models
{
    public class TransactionSummaryView
    {
     
        public int Id { get; set; }
        public int BillerId { get; set; }
        public Biller Biller { get; set; }
        public int?  LevelOneId{ get; set; }
        public LevelOne LevelOne { get; set; }
        public int? LevelTwoId { get; set; }
        public LevelTwo LevelTwo { get; set; }
        public decimal AmountCollected { get; set; }
        public decimal AmountPaid { get; set; }
        public bool isClosed { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateClosed { get; set; }


    }

}
