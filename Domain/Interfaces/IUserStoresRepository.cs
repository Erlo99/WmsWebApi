using Domain.Entities;
using Domain.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserStoresRepository
    {
        IEnumerable<UserStoresView> GetAllWithFilters(int? userId = null, int? storeId = null);
        UserStoresView Create(UserStores store);
        void Delete(int userId, int storeId);

    }
}
