using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Domain.Models.Nibss;
using ErcasCollect.Helpers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ErcasCollect.DataAccess.Repository
{
    public class NibssEbills : INibssEbills
    {
        private readonly IEbillsRemittance _ebillsRemittance;

        private readonly IEbillsNotification _ebillsNotification;

        public NibssEbills(IEbillsRemittance ebillsRemittance, IEbillsNotification ebillsNotification)
        {
            _ebillsRemittance = ebillsRemittance;

            _ebillsNotification = ebillsNotification;
        }

        public async Task<NotificationResponse> Notification(NotificationRequest request)
        {

            return await _ebillsNotification.Push(request);
        }

        public async Task<ValidationResponse> Validation(ValidationRequest request)
        {

            return _ebillsRemittance.Detail(request);
        }

    }
}
