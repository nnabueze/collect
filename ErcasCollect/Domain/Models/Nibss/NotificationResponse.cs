using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models.Nibss
{
    public class NotificationResponse
    {
        public string SessionID { get; set; }

        public string BillerID { get; set; }

        public string ResponseCode { get; set; }

        public string ResponseMessage { get; set; }

        public List<Params> Param { get; set; }

        public class Params
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}
