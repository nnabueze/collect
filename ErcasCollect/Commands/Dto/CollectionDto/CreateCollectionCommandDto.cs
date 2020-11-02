using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ErcasCollect.Commands.Dto.CollectionDto
{
    public class CreateCollectionComandDto
    {
        public string SessionId { get; set; }
        public string BatchId { get; set; }
        public string OfflineSessionId { get; set; }
        public string OfflineBatchId { get; set; }
        public List<SessionData> sessionData{ get; set; }


    }

    public class SessionData
    {


        [JsonIgnore]
        public string Id { get; set; } = Helpers.IdGenerator.IdGenerator.GetUniqueKey(10, 2);
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public int Createdby { get; set; }
     
       
        public string StatusId { get; set; }

        public SessionData sessionData { get; set; }
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        public string PosId { get; set; }

        public string PayerName { get; set; }
        public string PayerPhone { get; set; }
        public int TransactionTypeId { get; set; }
        public int PaymentChannelId { get; set; }



    }


}
