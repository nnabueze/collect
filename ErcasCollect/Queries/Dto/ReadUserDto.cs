using System;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Queries.Dto
{
    public class ReadUserDto
    {
        public int SsoId { get; set; }
    
        public Role Role { get; set; }
    
        public Biller Biller { get; set; }
    
        public LevelTwo LevelTwo { get; set; }

        public BillerType BillerType { get; set; }

        public LevelOne LevelOne { get; set; }

    
        public Status Status { get; set; }
   
        public decimal CollectionLimit { get; set; }
    }
}
