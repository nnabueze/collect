using System;
namespace ErcasCollect.Commands.Dto.PosDto
{
    public class ActivatePosDto
    {
        public int UserId { get; set; }
        public string PIN { get; set; }
        public int PosId { get; set; }
        public bool isActivation { get; set; }
    }
}
