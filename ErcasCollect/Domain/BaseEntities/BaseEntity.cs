using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErcasCollect.Domain.BaseEntities
{
    public class BaseEntity
    {
        [Key]
        [Column(TypeName = "nvarchar(32)")]
        public string Id { get; set; }
        public DateTime CreatedDate{ get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy{ get; set; }
        public int Createdby { get; set; }
        public bool IsDeleted { get; set; }

    }
}
