using System;
using System.Text.Json.Serialization;

namespace ErcasCollect.Commands.Dto.LevelTwoDto
{
    public class CreateLevelTwoDto:BaseDto
    {

        [JsonIgnore]
        public string Id { get; set; } = Helpers.IdGenerator.IdGenerator.GetUniqueKey(10, 2);
        public string Name { get; set; }
        public string BillerId { get; set; }
        public string LevelOneId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string StatusId { get; set; }
     
    }
}
