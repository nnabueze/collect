using ErcasCollect.Domain.Models.Nibss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Interfaces
{
    public interface IEbillsNotification
    {
        public Task<NotificationResponse> Push(NotificationRequest request);

        public NotificationResponse NotificationFailedResponse(NotificationRequest request, string message);
    }
}
