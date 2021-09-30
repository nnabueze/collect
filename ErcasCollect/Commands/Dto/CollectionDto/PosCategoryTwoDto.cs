using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Dto.CollectionDto
{
    public class PosCategoryTwoDto
    {
        public string BillerId { get; set; }

        public string PosId { get; set; }

        public string UserId { get; set; }

        public string CategoryOneId { get; set; }
    }

    public class PosCategoryTwoRespnse
    {
        public string CategoryOneId { get; set; }

        public string CategoryTwoDisplayName { get; set; }

        public IEnumerable<CategoryTwoParameter> CategoryTwo { get; set; }

        public class CategoryTwoParameter
        {
            public string ReferenceKey { get; set; }

            public string Name { get; set; }

            public decimal Amount { get; set; }

            public bool IsAmountFixed { get; set; }
        }
    }
}
