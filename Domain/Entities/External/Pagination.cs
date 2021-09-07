using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pagination
    {

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }

        public bool? OrderDescending { get; set; }

        public int TotalPages { get; set; }

    }
}
