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
        public int BatchId { get; set; }
        public string OfflineSessionId { get; set; }
        public string OfflineBatchId { get; set; }
        public int AgentId { get; set; }
        public int BillerId { get; set; }
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
        public int LevelThreeId { get; set; }
        public int LevelOneId { get; set; }
        public int LevelTwoId { get; set; }
        public string StatusId { get; set; }
       
        public SessionData sessionData { get; set; }
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        public int PosId { get; set; }

        public string PayerName { get; set; }
        public string PayerPhone { get; set; }
      
        public int PaymentChannelId { get; set; }



    }


}
