using System;
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
        public string Name { get; set; }

        public string Description { get; set; }
    }

}
