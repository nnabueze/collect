using System;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Queries.Dto
{
    public class ReadLevelThreeDto
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public Biller Biller { get; set; }
        public LevelOne LevelOne { get; set; }
        public LevelTwo LevelTwo { get; set; }
        public bool IsAmountFixed { get; set; }
    }
}
