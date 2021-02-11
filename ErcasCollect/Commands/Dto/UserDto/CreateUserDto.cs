using System;
using System.Collections.Generic;
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
        public int id { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string otherNames { get; set; }
    }

    public class UserResponseDto
    {
        public string ReferenceKey { get; set; }

        public string Role { get; set; }

        public string PhoneNumber { get; set; }

        public string BillerName { get; set; }

        public string LevelTwoName { get; set; }

        public string LevelOneName { get; set; }

        public bool IsActive { get; set; }

        public string CollectionLimit { get; set; }

        public string Name { get; set; }

        public string BillerId { get; set; }

        public string LevelOneId { get; set; }

        public string LevelTwoId { get; set; }
    }

    public class BillerUserResposeDto
    {
        public string LevelOneDisplayName { get; set; }

        public string LevelTwoDisplayName { get; set; }

        public List<UserResponseDto> Users { get; set; }
    }
}
