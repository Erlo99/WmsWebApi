using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserOperationsRepository : IUserOperationsRepository
    {

        private readonly WmsContext _context;

        public UserOperationsRepository(WmsContext context)
        {
            _context = context;
        }

        public UserOperations GetAllWithFilters(ref Pagination pagination, string userId = null, string LocationId = null, DateTime? operationDate = null, string storeId = null)
        {
            return new UserOperations();
        }
    }
}
