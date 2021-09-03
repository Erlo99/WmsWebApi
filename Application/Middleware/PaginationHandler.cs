using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Middleware
{
    public static class PaginationHandler
    {

        public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, ref Pagination pagination)
        {
            IEnumerable<TSource> records = null;

            pagination.TotalPages = (int)Math.Ceiling((source.Count() / (decimal)pagination.PageSize));
            if (pagination.OrderBy == null)
                records = source.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize);
            else
            {
                var propertyInfo = typeof(TSource).GetProperty(pagination.OrderBy);

                if (pagination.OrderDescending == true)
                    records = source.OrderByDescending(x => propertyInfo.GetValue(x, null));
                else
                    records = source.OrderBy(x => propertyInfo.GetValue(x, null));
            }
            return records;
            
        }
    }
}
