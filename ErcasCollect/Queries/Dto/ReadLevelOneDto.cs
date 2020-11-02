using System;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Queries.Dto
{
    public class ReadLevelOneDto
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public Biller Biller{ get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Status Status{ get; set; }
    
}
}
