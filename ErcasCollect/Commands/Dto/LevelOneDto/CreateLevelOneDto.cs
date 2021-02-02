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

    public class CloseBatchTransactionDto
    {
        public string BillerName { get; set; }

        public string TotalAmount { get; set; }

        public string IsPaid { get; set; }

        public string UserName { get; set; }

        public string GeneratedDate { get; set; }

        public string PaidDate { get; set; }

        public LevelOneDetail LevelOne { get; set; }

        public LevelTwoDetail LevelTwo { get; set; }


        public class LevelOneDetail
        {
            public string DisplayName { get; set; }

            public string Name { get; set; }
        }

        public class LevelTwoDetail
        {
            public string DisplayName { get; set; }

            public string Name { get; set; }
        }
    }


}
