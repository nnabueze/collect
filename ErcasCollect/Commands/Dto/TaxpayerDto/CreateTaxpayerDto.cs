using System;
using System.Text.Json.Serialization;

namespace ErcasCollect.Commands.Dto.TaxpayerDto
{
    public class CreateTaxpayerDto
    {
        [JsonIgnore]
        public string Id { get; set; } = Helpers.IdGenerator.IdGenerator.GetUniqueKey(8, 2);
        public string Name { get; set; }
        public string BillerId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StatustId { get; set; }
     
    }
}
