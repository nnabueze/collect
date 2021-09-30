using ErcasCollect.Domain.Models;
using ErcasCollect.Domain.Models.Nibss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Interfaces
{
    public interface IEbillsRemittance
    {
        public ValidationResponse Detail(ValidationRequest request);

        public ValidationResponse RemittanceFailedResponse(ValidationRequest request, string message);
    }
}
