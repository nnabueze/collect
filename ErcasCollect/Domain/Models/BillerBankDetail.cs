using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class BillerBankDetail
    {
        public int Id { get; set; }
        public string BillerId { get; set; }
        public Biller Biller { get; set; }
        public string BankId { get; set; }
        public Bank Bank { get; set; }
        public string AccountNumber { get; set; }
   
        public string BVN{ get; set; }
        public bool IsValidated { get; set; }
        public string AccountName { get; set; }
      
    }
}
