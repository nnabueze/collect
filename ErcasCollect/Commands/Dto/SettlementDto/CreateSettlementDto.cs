using System;
using System.Text.Json.Serialization;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Commands.Dto.SettlementDto
{
    public class CreateSettlementDto
    {
        [JsonIgnore]
        public string Id { get; set; } = Helpers.IdGenerator.IdGenerator.GetUniqueKey(10, 2);
        public string BankId { get; set; }
   
        public string BillerId { get; set; }
   
        public int PaymentChannelId { get; set; }
  

        public int TransactionTypeId { get; set; }



        public string PaidBy { get; set; }
      
        public string PayerPhone { get; set; }

        public string ReferenceID { get; set; }
    }
}
