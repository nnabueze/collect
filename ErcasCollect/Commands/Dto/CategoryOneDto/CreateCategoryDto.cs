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
}
