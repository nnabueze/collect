using System;
namespace ErcasCollect.Commands.Dto.PosDto
{
    public class ActivatePosDto
    {
        public string UserId { get; set; }
        public string PIN { get; set; }
        public string PosId { get; set; }
        public bool isActivation { get; set; }
    }
}
