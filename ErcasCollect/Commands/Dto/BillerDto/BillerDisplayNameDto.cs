using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Dto.BillerDto
{
    public class BillerDisplayNameDto
    {
        public string BillerId { get; set; }

        public string LevelOneDisplayName { get; set; }

        public string LevelTwoDisplayName { get; set; }

        public string CategoryOneDisplayName { get; set; }

        public string CategoryTwoDisplayName { get; set; }
    }
}
