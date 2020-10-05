using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Commands.Dto.LevelOneDto
{
    public class CreateLevelOneDto:BaseDto
    {
        [JsonIgnore]
        public string Id { get; set; } = Helpers.IdGenerator.IdGenerator.GetUniqueKey(10, 2);
        public string Name { get; set; }
        public string Description { get; set; }
        public string BillerId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string StatusId { get; set; }
    }

}
