using System;
namespace ErcasCollect.Domain.Models
{
    public class FundSweep
    {
        public int Id { get; set; }
        public int? BillerId { get; set; }
        public Biller Biller { get; set; }
        public int? LevelOneId { get; set; }
        public LevelOne LevelOne{ get; set; }
        public int? LevelTwoId{ get; set; }
        public LevelTwo LevelTwo { get; set; }
        public int? BankId { get; set; }
        public Bank Bank { get; set; }
        public string AccountNumber { get; set; }
        public  decimal Amount{ get; set; }
        public DateTime DateProcessed { get; set; }
        public  DateTime DateCreated { get; set; }
        public bool isProcessed { get; set; }
        public bool isConfirmed { get; set; }
        public int ConfirmedBy { get; set; }
    }
}
