using System;
using System.Text.Json.Serialization;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Commands.Dto.BillerDto
{
    public class ReadBillerDto
    {
  
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public int StateId { get; set; }
        public string State { get; set; }
        [JsonIgnore]
        public int BillerTypeId { get; set; } 
        public string BillerType { get; set; } 
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Abbreviation { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
