using System;
using System.ComponentModel.DataAnnotations;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class Batch : TransactionBaseEntity
    {
        
        public int ItemCount { get; set; }
        public bool isOffline { get; set; }
        public string OfflineId { get; set; }
        public string StatusId { get; set; }
        public Status Status { get; set; }
    }
}
