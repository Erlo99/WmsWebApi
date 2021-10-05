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

        public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, PaginationDto paginationData)
        {

            Pagination pagination = _mapper.Map<Pagination>(paginationData);
            pagination.TotalPages = (int)Math.Ceiling((source.Count() / (decimal)pagination.PageSize));
            if (pagination.OrderBy != null)
            {
                var propertyInfo = typeof(TSource).GetProperty(pagination.OrderBy);

                if (pagination.OrderDescending == true)
                    source = source.OrderByDescending(x => propertyInfo.GetValue(x, null));
                else
                    source = source.OrderBy(x => propertyInfo.GetValue(x, null));
            }
            source = source.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize);

            return source;
            
        }
    }
}
