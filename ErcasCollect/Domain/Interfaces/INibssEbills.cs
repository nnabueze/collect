using ErcasCollect.Domain.Models.Nibss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Interfaces
{
    public interface INibssEbills
    {
        public Task<ValidationResponse> Validation(ValidationRequest request);

        public Task<NotificationResponse> Notification(NotificationRequest request);

    }
}
