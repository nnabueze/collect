using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class Biller:BaseEntity
    {
        [Column(TypeName = "nvarchar(32)")]

        public string ReferenceKey { get; set; } 

        [Column(TypeName = "nvarchar(32)")]

        public string Name { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string Address { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string Email { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string  Description{ get; set; }

        public int?  StateId { get; set; }

        public State State { get; set; }

        public int? BillerTypeId{ get; set; }

        public BillerType BillerType{ get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string BillerTin { get; set; }

        [Column(TypeName = "decimal(18,6)")]

        public decimal Latitude { get; set; }

        [Column(TypeName = "decimal(18,6)")]

        public decimal  Longitude { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string Abbreviation { get; set; }

        public int Commission { get; set; }

        public bool IsGatewayOnbaord { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string GatewayUsername { get; set; }
        
        [Column(TypeName = "nvarchar(32)")]

        public string GatewaySecretKey { get; set; }

        [Column(TypeName = "nvarchar(32)")]

        public string GatewayKeyVector { get; set; }


        public ICollection<LevelOne> LevelOne { get; set; }

        public ICollection<LevelTwo> LevelTwo { get; set; }
    }
}
