using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErcasCollect.Commands.Dto
{
    public class TransactionBaseDto
    {
        public string Id { get; set; }
    
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
