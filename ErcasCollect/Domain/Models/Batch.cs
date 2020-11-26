using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class Batch 
    {
        [Key]
        public string Id { get; set; }= Helpers.IdGenerator.IdGenerator.GetUniqueKey(10, 2);
        public int ItemCount { get; set; }
        
        public string OfflineId { get; set; }
   
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string AgentId { get; set; }
        public User Agent { get; set; }
        public string BillerId { get; set; }
        public Biller  Biller { get; set; }
      


    }
}
