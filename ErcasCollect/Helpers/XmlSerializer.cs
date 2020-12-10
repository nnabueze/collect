using System;
using System.Collections.Generic;
using ErcasCollect.Responses;

namespace ErcasCollect.Helpers
{
    public class XmlSerializer
    {
        public static List<Param> ValidationParamArray(ValidationResponse response )
        {
            Dictionary<string, string> Result = new Dictionary<string, string>();
            List<Param> resposeParam = new List<Param>();

            //Result.Add("meterNumber", meterNumber);
            //Result.Add("meterType", meterType);
         
            //Result.Add("ercasBillerId", ercasBillerId);
            //Result.Add("payerEmail", payerEmail);
            //Result.Add("payerPhone", payerPhone);

            foreach (var item in Result)
            {
                Param p = new Param();
                p.Key = item.Key;
                p.Value = item.Value;

                resposeParam.Add(p);

            }

            return resposeParam;

        }
    }
}
