using System;
namespace ErcasCollect.Commands.Dto.CollectionDto
{
    public class GenerateRemittanceDto
    {
        public int AgentId { get; set; }
        public bool ForceGenerate { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

    }
}
