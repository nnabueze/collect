using System;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Queries.Dto
{
    public class ReadLevelTwoDto
    {
   
        public string Id { get; set; } 
        public string Name { get; set; }
        public Biller Biller { get; set; }
        public string LevelOneId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public Status Status{ get; set; }
    }
}
