using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Dto.BillerDto
{
    public class EbillsNotificationDto
    {
        public string BillerId { get; set; }

        public string BillerProductId { get; set; }

        public string NotificationField { get; set; }


    }

    public class ParamField
    {
        public string NotificationField { get; set; }
    }

    public class BillerNotificationDto
    {
        public string NotificationName { get; set; }
    }
}
