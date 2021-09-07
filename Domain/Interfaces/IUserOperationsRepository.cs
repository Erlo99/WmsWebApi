using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserOperationsRepository
    {
        UserOperations GetAllWithFilters(ref Pagination pagination, string userId = null, string LocationId = null, DateTime? operationDate = null, string storeId = null);
    }
}
