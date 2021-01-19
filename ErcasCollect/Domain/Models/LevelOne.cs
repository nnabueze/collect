﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class LevelOne:BaseEntity
    {
     
        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string Description { get; set; }
        public int BillerId { get; set; }
        public Biller Biller { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Longitude { get; set; }
        public int StatusCode { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal FundsweepPercentage { get; set; }
    }
}
