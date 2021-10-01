using Application.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface IUserOperationService
    {
        (IEnumerable<UserOperationDto>,PagedDto) GetAllWithFilters(ref PaginationDto pagination, string userName = null, string LocationName = null, DateTime? operationDate = null, string storeName = null, string operationName = null);
    }
}

