using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Helpers
{
    public class WebEndpoint
    {
        public string GatewayOnBoard { get; set; }

        public string GatewayServices { get; set; }

        public string GatewayCallbackUrl { get; set; }

        public string Mail { get; set; }

        public string MailTransaction { get; set; }

        public string EbillsPay { get; set; }

        public string SsoUserLogin { get; set; }

        public string SsoUserCreate { get; set; }

        public string GenerateERNUrl { get; set; }
    }
}
