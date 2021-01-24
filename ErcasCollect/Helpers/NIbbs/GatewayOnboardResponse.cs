using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Helpers.NIbbs
{
    public class GatewayOnboardResponse
    {
        public bool status { get; set; }

        public int statusCode { get; set; }

        public string message { get; set; }

        public Data data { get; set; }

        public class Data
        {
            public string username { get; set; }

            public string secretKey { get; set; }

            public string keyVector { get; set; }
        }
    }

}
