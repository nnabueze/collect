using System;
namespace ErcasCollect.Domain.Models
{
    public class NumberSeries
    {
        public int Id { get; set; }
        public string IdFor { get; set; }
        public string Acronym { get; set; }
        public int LastIssued { get; set; }
        public DateTime LastDateIssued { get; set; }
    }
}
