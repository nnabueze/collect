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

    public class CategoryTwoResponseDto
    {
        public string DisplayName { get; set; }

        public IEnumerable<CategoryTwoItem> CategoryTwoItems { get; set; }

        public class CategoryTwoItem
        {
            public string ReferenceKey { get; set; }

            public decimal Amount { get; set; }

            public bool IsAmountFixed { get; set; }
        }
    }
}
