using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErcasCollect.Domain.BaseEntities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy{ get; set; }

        public int Createdby { get; set; }

        public bool IsDeleted { get; set; }

    }
}
