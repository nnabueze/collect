using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Helpers.NIbbs
{
    public class GatewayServiceResponse
    {
        public bool status { get; set; }

        public int statusCode { get; set; }

        public string message { get; set; }

        public List<Data> data { get; set; }


    }

    public class Data
    {
        public int id { get; set; }

        public string serviceName { get; set; }

        public string serviceCallBack { get; set; }

        public string description { get; set; }
    }

    public class BillerData
    {
        public string companyName { get; set; }

        public string companyEmail { get; set; }

        public string companyPhone { get; set; }

        public string companyInformation { get; set; }

        public string address { get; set; }

        public List<Services> services { get; set; }
       
    }
    public class Services
    {
        public int id { get; set; }
    }

    public class CallbackUrl
    {
        public string secretKey { get; set; }

        public string validationUrl { get; set; }

        public string notificationUrl { get; set; }

        public string keyVector { get; set; }
    }

}
