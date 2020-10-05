using System;
namespace ErcasCollect.Commands.Dto.BillerDto
{
    public class AddTinDto
    {
        public string BillerId { get; set; }
   
        public string TIN { get; set; }
        public bool IsValidated { get; set; }
    }
}
