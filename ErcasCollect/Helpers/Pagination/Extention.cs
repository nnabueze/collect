using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ErcasCollect.Helpers.Pagination
{
    public static class Extensions
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, PaginationFilter pf) where
            T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = pf.PageNumber,
                PageSize = pf.PageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pf.PageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (pf.PageNumber - 1) * pf.PageSize;
            result.Data = query.Skip(skip).Take(pf.PageSize).ToList();

            return result;
        }
    }
}
