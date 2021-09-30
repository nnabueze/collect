using ErcasCollect.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Helpers
{
    public class ResponseGenerator
    {
        public static SuccessfulResponse Response(string msg, int code, bool status, object data = null)
        {
            return new SuccessfulResponse()
            {
                Message = msg,

                StatusCode = code,

                IsSuccess = status,

                Data = data
            };
        }
    }
}
