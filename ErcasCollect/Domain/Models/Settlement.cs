﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;
using ErcasCollect.Helpers.EnumClasses;

namespace ErcasCollect.Domain.Models
{
    public class Settlement:TransactionBaseEntity
    {
        public string Bank { get; set; }

        public int? BillerId { get; set; }

        public Biller Biller{ get; set; }

        public PaymentChannels PaymentChannel { get; set; }

        public TypesOfTransaction TransactionType { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string PaidBy { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string PayerPhone { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string ReferenceID { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string TransactionNumber { get; set; }

        public string TransactionStatus { get; set; }

        public int StatusCode { get; set; }



    }
}
