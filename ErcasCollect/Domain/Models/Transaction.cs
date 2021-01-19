using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class Transaction:BaseEntity
    {

        public int StatusCode { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string RemittanceNumber { get; set; }
        public int PosId { get; set; }
        public Pos Pos { get; set; }
        public string PayerName { get; set; }
        public string PayerPhone{ get; set; }
        public int AgentId { get; set; }
        public User Agent { get; set; }
        public string SessionId { get; set; }
        public string OfflineSessionId { get; set; }
        public int BillerId { get; set; }
        public Biller Biller { get; set; }
        public int BatchId { get; set; }
        public string OfflineBatchId { get; set; }
        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }
        public int PaymentChannelId { get; set; }

        public string TransactionNumber { get; set; }
        public PaymentChannel PaymentChannel{ get; set; }
        public int LevelOneId { get; set; }
        public LevelOne LevelOne { get; set; }
        public int LevelTwoId { get; set; }
        public LevelTwo LevelTwo { get; set; }
        public int LevelThreeId { get; set; }
        public LevelThree LevelThree { get; set; }




    }
}
