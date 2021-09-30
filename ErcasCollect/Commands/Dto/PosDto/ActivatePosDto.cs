using System;
namespace ErcasCollect.Commands.Dto.PosDto
{
    public class ActivatePosDto
    {
        public string ActivationPin { get; set; }
    }

    public class PosDetailsDto
    {
        public string PosId { get; set; }

        public string BillerId { get; set; }

        public string LevelOneId { get; set; }

        public string LevelTwoId { get; set; }
    }
}
