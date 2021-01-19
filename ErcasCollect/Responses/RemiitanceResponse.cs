using System;
namespace ErcasCollect.Responses
{
    public class RemiitanceResponse
    {
        public decimal Amount { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string RemittanceID { get; set; }
    }
}
