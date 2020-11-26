using System;
using System.Collections.Generic;
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

        public List<TransactionDetail> transactionDetail{ get; set; }

        public string PaidBy { get; set; }
      
        public string PayerPhone { get; set; }

        public string ReferenceID { get; set; }
        public string TransactionID { get; set; }
        public decimal Amount { get; set; }
        public string StatusId{ get; set; }
        public string AgentId { get; set; }

    }

    public class TransactionDetail
    {


        [JsonIgnore]
        public string Id { get; set; } = Helpers.IdGenerator.IdGenerator.GetUniqueKey(10, 2);
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public int Createdby { get; set; }
        public string LevelThreeId { get; set; }
        public string LevelOneId { get; set; }
        public string LevelTwoId { get; set; }


        public TransactionDetail transactionDetail { get; set; }
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        //public string PosId { get; set; }

        //public string PayerName { get; set; }
        //public string PayerPhone { get; set; }

        //public int PaymentChannelId { get; set; }




    }
}
