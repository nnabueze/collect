using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Dto.CollectionDto
{
    public class PosLogoutDto
    {
        public string BillerId { get; set; }

        public string PosId { get; set; }

        public string UserId { get; set; }
    }
}
