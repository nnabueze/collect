using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Dto.CategoryOneDto
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }

        public string BillerId { get; set; }

        public string LevelOneId { get; set; }
    }

    public class UpdateCategoryOneDto
    {
        public string Name { get; set; }

        public string BillerId { get; set; }

        public string LevelOneId { get; set; }

        public string CategoryOneId { get; set; }
    }

    public class CategoryOneResponseDto
    {
        public string DisplayName { get; set; }

        public IEnumerable<CategoryOneItem> CategoryOneItems { get; set; }

        public class CategoryOneItem
        {
            public string ReferenceKey { get; set; }

            public string Name { get; set; }
        }
    }

}
