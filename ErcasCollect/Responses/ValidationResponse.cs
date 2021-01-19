using System;
using System.Collections.Generic;

namespace ErcasCollect.Responses
{
    public class ValidationResponse
    {
     

        public int? BillerID { get; set; }
        public int ResponseCode { get; set; }
        public int NextStep { get; set; }

        public List<Param> Params { get; set; }

    }


}

