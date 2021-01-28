using ErcasCollect.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models
{
    public class PosLocation : BaseEntity
    {
        public int? BillerId { get; set; }

        public Biller Biller { get; set; }

        public int? PosId { get; set; }

        public Pos Pos { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
