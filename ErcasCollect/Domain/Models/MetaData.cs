using System;
namespace ErcasCollect.Domain.Models
{
    public class MetaData
    {
        public int Id { get; set; }
        public string  BillerTypeId { get; set; }
        public  BillerType BillerTypes{ get; set; }
        public string FieldOne{ get; set; }
        public string FieldTwo { get; set; }
        public string FieldThree { get; set; }
        public string FieldFour { get; set; }
        public string FieldFive { get; set; }
        public string FieldSix { get; set; }
        public string FieldSeven { get; set; }
        public string FieldEight { get; set; }
    }
}
