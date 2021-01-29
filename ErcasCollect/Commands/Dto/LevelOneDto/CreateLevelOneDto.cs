using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Commands.Dto.LevelOneDto
{
    public class CreateLevelOneDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string BillerId { get; set; }

        public string FundsweepPercentage { get; set; }
    }

    public class UpdateLevelOneDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string LevelOneId { get; set; }

        public string BillerId { get; set; }

        public string FundsweepPercentage { get; set; }
    }

    public class LevelOneResponseDto
    {
        public string DisplayName { get; set; }

        public IEnumerable<LevelOneItem> LevelOneItems { get; set; }

        public class LevelOneItem
        {
            public string ReferenceKey { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }
        }
    }

}
