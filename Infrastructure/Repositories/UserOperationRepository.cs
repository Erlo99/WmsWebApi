using Application.Middleware;
using Domain.Entities;
using Domain.Entities.Views;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserOperationRepository : IUserOperationRepository
    {

        private readonly WmsContext _context;

        public UserOperationRepository(WmsContext context)
        {
            _context = context;
        }

        public IEnumerable<UserOperation> GetAllWithFilters(ref Pagination pagination, string userName = null, string locationName = null, DateTime? operationDate = null, string storeName = null, string operationName = null)
        {
            var usersOperations = _context.UserOperations.AsEnumerable();


            if (userName != null)
                usersOperations.Where(x => x.UserName == userName);
            if (locationName != null)
                usersOperations.Where(x => x.LocationName == locationName);
            if (operationDate != null)
                usersOperations.Where(x => x.OperationDate == operationDate);
            if (storeName != null)
                usersOperations.Where(x => x.StoreName == storeName);
            if (operationName != null)
                usersOperations.Where(x => x.OperationName == operationName);

            return PaginationHandler.Page<UserOperation>(usersOperations, ref pagination);
        }

    }
}
