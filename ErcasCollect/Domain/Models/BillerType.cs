using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class BillerType
    {
        [Key]
        public int Id {get; set;}
        [Column(TypeName = "nvarchar(32)")]
        public string Category { get; set; }
     

    }
}
