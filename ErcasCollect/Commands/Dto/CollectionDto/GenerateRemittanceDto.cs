using System;
namespace ErcasCollect.Commands.Dto.CollectionDto
{
    public class GenerateRemittanceDto
    {
        public string BillerId { get; set; }

        public string PosId { get; set; }

        public string UserId { get; set; }

    }

    public class GenerateErnDto
    {
        public bool status { get; set; }

        public int statusCode { get; set; }

        public string message { get; set; }

        public DataDetails data { get; set; }

        public class DataDetails
        {
            public string generateERN { get; set; }
        }
    }
}
