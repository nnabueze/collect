using System;
namespace ErcasCollect.Commands.Dto.BillerDto
{
    public class AddBankDto
    {
   
        public string BillerId { get; set; }
        public string BankId { get; set; }

        public string AccountNumber { get; set; }
        public string BVN { get; set; }
        public bool IsValidated { get; set; }
        public string AccountName { get; set; }
    }
}
