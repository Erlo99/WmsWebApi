using Domain.Entities;
using Domain.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserOperationRepository
    {
        IEnumerable<UserOperation> GetAllWithFilters(ref Pagination pagination, string userName = null, string LocationName = null, DateTime? operationDate = null, string storeName = null, string operationName = null);

    }
}
