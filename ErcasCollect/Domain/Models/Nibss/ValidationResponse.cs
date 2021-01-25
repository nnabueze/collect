using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models.Nibss
{
    public class ValidationResponse
    {
        public string BillerID { get; set; }

        public string NextStep { get; set; }

        public string ResponseCode { get; set; }

        public List<Params> Param { get; set; }

        public class Params
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}
