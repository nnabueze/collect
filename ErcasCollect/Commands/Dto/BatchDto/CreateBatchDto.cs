using System;
namespace ErcasCollect.Commands.Dto.BatchDto
{
    public class CreateBatchDto
    {

        public int ItemCount { get; set; }
        public bool isOffline { get; set; }
        public string OfflineId { get; set; }
        public string StatusId { get; set; }
        public string BillerId { get; set; }

    }
}
