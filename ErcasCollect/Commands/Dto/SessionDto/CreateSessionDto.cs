using System;
using System.Text.Json.Serialization;

namespace ErcasCollect.Commands.Dto.SessionDto
{
    public class CreateSessionDto
    {
        [JsonIgnore]
        public string Id { get; set; } = Helpers.IdGenerator.IdGenerator.GetUniqueKey(8, 2);
        public string OfflineId { get; set; }
    }
}
