using System;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class Session:TransactionBaseEntity
    {
        public int ItemCount { get; set; }
    }
}
