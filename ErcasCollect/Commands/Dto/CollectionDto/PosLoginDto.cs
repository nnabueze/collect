using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Dto.CollectionDto
{
    public class PosLoginDto
    {
        public string PosId { get; set; }

        public string BillerId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class SsoLoginDto
    {
        public int id { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string otherNames { get; set; }

        public string lastLoginDate { get; set; }

        public string token { get; set; }
    }

    public class PosLoginResponseDto
    {
        public string PosId { get; set; }

        public string BillerId { get; set; }

        public string LevelOneDisplayName { get; set; }

        public IEnumerable<LevelOneParameter> LevelOne { get; set; }

        public class LevelOneParameter
        {
            public string Name { get; set; }

            public string ReferenceKey { get; set; }
        }
    }
}
