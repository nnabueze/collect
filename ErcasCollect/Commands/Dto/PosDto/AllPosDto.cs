using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Dto.PosDto
{
    public class AllPosDto
    {

        public string BillerName { get; set; }

        public string PosId { get; set; }

        public string LevelOne  { get; set; }

        public string LevelTwo { get; set; }

        public string IsActive { get; set; }

        public string PosImei { get; set; }

        public string ActivationPin { get; set; }

        public string IsLogin { get; set; }

        public string LoginUserName { get; set; }

        public string LastLoginUserName { get; set; }
    }
}
