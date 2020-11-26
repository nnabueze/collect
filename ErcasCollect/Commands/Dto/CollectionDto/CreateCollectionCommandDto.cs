using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ErcasCollect.Commands.Dto.CollectionDto
{
    public class SettlementCollectionComandDto
    {
        [JsonIgnore]
        public string SessionId { get; set; }= Helpers.IdGenerator.IdGenerator.GetUniqueKey(10,2);
        [JsonIgnore]
        public string BatchId { get; set; }= Helpers.IdGenerator.IdGenerator.GetUniqueKey(10, 2);
        public string OfflineSessionId { get; set; }
        public string OfflineBatchId { get; set; }
        public string AgentId { get; set; }
        public string BillerId { get; set; }
        public int ItemCount { get; set; }
        public decimal Amount { get; set; }
        public List<SessionData> sessionData{ get; set; }
        public int TransactionTypeId { get; set; }


    }

    public class SessionData
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
        public string StatusId { get; set; }
       
        public SessionData sessionData { get; set; }
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        public string PosId { get; set; }

        public string PayerName { get; set; }
        public string PayerPhone { get; set; }
      
        public int PaymentChannelId { get; set; }



    }


}
