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
        public string email { get; set; }
        public string password { get; set; }
        public string phone{ get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string Name { get; set; }

    }
}
