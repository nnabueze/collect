using System;
using System.Text.Json.Serialization;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Commands.Dto.LevelThreeDto
{
    public class CreateLevelThreeDto
    {

        [JsonIgnore]
        public string Id { get; set; } = Helpers.IdGenerator.IdGenerator.GetUniqueKey(10, 2);

        public string Name { get; set; }

        public decimal Amount { get; set; }
        public string BillerId { get; set; }
        public string LevelOneId { get; set; }
        public string LevelTwoId { get; set; }
    
        public bool IsAmountFixed { get; set; }
    }
}
