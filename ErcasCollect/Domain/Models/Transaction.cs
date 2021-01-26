using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;
using ErcasCollect.Helpers.EnumClasses;

namespace ErcasCollect.Domain.Models
{
    public class Transaction:BaseEntity
    {

        public int StatusCode { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string RemittanceNumber { get; set; }
        public int? PosId { get; set; }
        public Pos Pos { get; set; }
        public string PayerName { get; set; }
        public string PayerPhone{ get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public string SessionId { get; set; }
        public string OfflineSessionId { get; set; }
        public int? BillerId { get; set; }
        public Biller Biller { get; set; }
        public int BatchId { get; set; }
        public string OfflineBatchId { get; set; }
        public TypesOfTransaction TransactionType { get; set; }
        public string TransactionNumber { get; set; }
        public PaymentChannels PaymentChannel{ get; set; }
        public int? CategoryTwoServiceId { get; set; }

        public CategoryTwoService CategoryTwoService { get; set; }
    }
}
