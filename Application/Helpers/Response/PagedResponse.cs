using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class PagedResponse <T>
    {

        public PagedResponse((IEnumerable<T>, PagedDto) data)
        {
            Data = data.Item1;
            PageNumber = data.Item2.PageNumber;
            PageSize = data.Item2.PageSize;
            TotalPages = data.Item2.TotalPages;
        }

        public IEnumerable<T> Data { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}
