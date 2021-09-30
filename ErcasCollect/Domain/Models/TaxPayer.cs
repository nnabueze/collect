using System;

using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class TaxPayer:BaseEntity
    {
      
        public string Name { get; set; }
        public int? BillerId { get; set; }
        public Biller Biller{ get; set; }
        public string Email{ get; set; }
        public string PhoneNumber{ get; set; }
        public int StatusCode { get; set; }
        public DateTime LastPaidDate { get; set; }

    }
}
