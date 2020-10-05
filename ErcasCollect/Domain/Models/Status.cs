using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ErcasCollect.Domain.Models
{
    public class Status
    {
        [Key]
        [Column(TypeName = "nvarchar(32)")]
        public string Id { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }
      
    }
}
