using System;
using System.Text.Json.Serialization;

namespace ErcasCollect.Commands.Dto.TransactionDto
{
    public class TransactionDto:BaseDto
    {
        [JsonIgnore]
        public string Id { get; set; } = Helpers.IdGenerator.IdGenerator.GetUniqueKey(10, 2);
        public string OfflineId { get; set; }
        public string BatchId { get; set; }
        public string StatusId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        public string PosId { get; set; }
        public string UserId { get; set; }
        public int TransactionTypeId { get; set; }
        public int PaymentChannelId { get; set; }

    }
}
