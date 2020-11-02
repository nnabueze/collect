using System;
using System.Text.Json.Serialization;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Commands.Dto.UserDto
{
    public class CreateUserDto:BaseDto
    {
        [JsonIgnore]
        public string Id { get; set; } = Helpers.IdGenerator.IdGenerator.GetUniqueKey(6, 2);
        public int SsoId { get; set; }
        public int RoleId { get; set; }
        public string BillerId { get; set; }
        public string LevelOneId { get; set; }
        public string LevelTwoId { get; set; }
        public string StatusId { get; set; }
        public decimal CollectionLimit { get; set; }
        public string Password { get; set; }
        public string  Pin { get; set; }
    }
}
