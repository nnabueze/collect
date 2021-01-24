using System;
namespace ErcasCollect.Commands.Dto.BillerDto
{
    public class UpdateBillerDetailDto:BaseDto
    {
        public string BillerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public int StateId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Abbreviation { get; set; }
    }
}
