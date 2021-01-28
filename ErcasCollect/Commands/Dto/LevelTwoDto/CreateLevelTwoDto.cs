using System;
using System.Text.Json.Serialization;

namespace ErcasCollect.Commands.Dto.LevelTwoDto
{
    public class CreateLevelTwoDto
    {
        public string Name { get; set; }

        public string BillerId { get; set; }

        public string LevelOneId { get; set; }
     
    }

    public class UpdateLevelTwoDto
    {
        public string Name { get; set; }

        public string BillerId { get; set; }

        public string LevelOneId { get; set; }

        public string LevelTwoId { get; set; }
    }
}
