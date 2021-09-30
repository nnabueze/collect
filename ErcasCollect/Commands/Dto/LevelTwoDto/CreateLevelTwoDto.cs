using System;
using System.Collections.Generic;
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

    public class GetLevelTwo
    {
        public string BillerId { get; set; }

        public string LevelOneId { get; set; }
    }

    public class LevelTwoResponseDto
    {
        public string DisplayName { get; set; }

        public IEnumerable<LevelTwoItem> LevelTwoItems { get; set; }

        public class LevelTwoItem
        {
            public string ReferenceKey { get; set; }

            public string Name { get; set; }
        }
    }
}
