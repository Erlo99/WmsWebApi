using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class PaginationDto : IMap
    {
        public PaginationDto()
        {
            PageNumber = 1;
            PageSize = 50;
        }

        public PaginationDto(int pageNumber, int? pageSize = null, string orderBy = null, bool? orderDescending = null)
        {
            PageNumber = pageNumber;
            PageSize = (pageSize > 100 ? 100 : pageSize) ?? 50;
            OrderBy = orderBy;
            OrderDescending = orderDescending;
        }

        public int PageNumber {get; set;}
        public int PageSize { get; set; }

        public string OrderBy { get; set; }
        public bool? OrderDescending { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PaginationDto, Pagination>();
        }
    }
}
