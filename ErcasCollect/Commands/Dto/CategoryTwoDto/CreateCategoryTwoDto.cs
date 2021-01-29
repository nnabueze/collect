using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Dto.CategoryTwoDto
{
    public class CreateCategoryTwoDto
    {
        public string Name { get; set; }

        public string Amount { get; set; }

        public string BillerId { get; set; }

        public string LevelOneId { get; set; }

        public string CategoryOneId { get; set; }

        public string IsAmountFixed { get; set; }
    }

    public class UpdateCategoryTwoDto
    {
        public string Name { get; set; }

        public string Amount { get; set; }

        public string BillerId { get; set; }

        public string LevelOneId { get; set; }

        public string CategoryOneId { get; set; }

        public string IsAmountFixed { get; set; }

        public string CategoryTwoId { get; set; }
    }
}
