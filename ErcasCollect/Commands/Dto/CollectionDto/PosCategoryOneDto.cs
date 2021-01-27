using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Dto.CollectionDto
{
    public class PosCategoryOneDto
    {
        public string BillerId { get; set; }

        public string PosId { get; set; }

        public string UserId { get; set; }

        public string LevelOneId { get; set; }
    }

    public class PosCategoryOneRespnse
    {
        public string LevelOneId { get; set; }

        public string CategoryOneDisplayName { get; set; }

        public IEnumerable<CategoryOneParameter> CategoryOne { get; set; }

        public class CategoryOneParameter
        {
            public string ReferenceKey { get; set; }

            public string Name { get; set; }
        }
    }
}
