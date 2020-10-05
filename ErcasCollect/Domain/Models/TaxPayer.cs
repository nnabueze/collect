using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class TaxPayer:BaseEntity
    {
      
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string BillerId { get; set; }
        public Biller Biller{ get; set; }
        public string Email{ get; set; }
        public string PhoneNumber{ get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string StatustId { get; set; }
        public Status Status { get; set; }
      
    }
}
