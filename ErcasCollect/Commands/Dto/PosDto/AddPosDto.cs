using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Dto.PosDto
{
    public class AddPosDto
    {
        public string LevelOneId { get; set; }

        public string LevelTwoId { get; set; }

        public string BillerId { get; set; }

        public string PosImei { get; set; }
    }
}
