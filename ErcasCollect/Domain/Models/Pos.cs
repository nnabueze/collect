using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Models
{
    public class Pos:BaseEntity
    {

        public string ReferenceKey { get; set; }

        public bool IsActive { get; set; }

        public bool IsLogin { get; set; }

        public int? BillerId{ get; set; }

        public Biller Biller { get; set; }

        public int? LevelOneId { get; set; }

        public LevelOne LevelOne{ get; set; }

        public string Activationpin { get; set; }

        public int? LevelTwoId{ get; set; }

        public LevelTwo LevelTwo { get; set; }

        public int? UserId { get; set; }

        public int? LastUserId { get; set; }

        public string PosImei { get; set; }

    }
}
