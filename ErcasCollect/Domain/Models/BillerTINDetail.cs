using System;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class BillerTINDetail
    {
        public int Id { get; set; }

        public int? BillerId { get; set; }
        public Biller  Biller { get; set; }
        public string TIN { get; set; }
        public bool IsValidated { get; set; }
    }
}
