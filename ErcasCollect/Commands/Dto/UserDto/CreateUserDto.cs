using System;
using System.Text.Json.Serialization;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Commands.Dto.UserDto
{
    public class CreateUserDto
    {
        public int RoleId { get; set; }
        public string BillerId { get; set; }
        public string LevelOneId { get; set; }
        public string LevelTwoId { get; set; }
        public decimal CollectionLimit { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone{ get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

    }

    public class SsoCreateUserResponseDto
    {
        public int Id { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherNames { get; set; }
    }
}
