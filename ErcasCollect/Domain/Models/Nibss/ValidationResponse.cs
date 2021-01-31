using ErcasCollect.Commands.Dto.BillerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models.Nibss
{
    public class ValidationResponse
    {
        public string BillerID { get; set; }

        public string NextStep { get; set; }

        public string ResponseCode { get; set; }

        public List<ParamData> Params { get; set; }

        public Field Field { get; set; }

        public PaymentDetail PaymentDetail { get; set; }

        public class ParamData
        {
            public string Key { get; set; }

            public string Value { get; set; }
        }
    }


    public class Field
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public bool Required { get; set; }

        public bool Readonly { get; set; }

        public int MaxLength { get; set; }

        public int Order { get; set; }

        public bool RequiredInNextStep { get; set; }

        public bool AmountField { get; set; }

        public List<DetailItem> Items { get; set; }
    }

    public class DetailItem
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
