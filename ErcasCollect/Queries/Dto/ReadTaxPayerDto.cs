using System;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Queries.Dto
{
    public class ReadTaxPayerDto
    {
        public string Name { get; set; }     
        public int BillerId { get; set; }
        public Biller Biller { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
     
       
        public Status Status { get; set; }
    }
}
