using Domain.Entities;
using Domain.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserStoreRepository
    {
        IEnumerable<UserStoreView> GetAllWithFilters(int? userId = null, int? storeId = null);
        UserStoreView Create(UserStore userStore);
        void Delete(UserStore userStore);

        void InsertDefaultStores(int userId);
        UserStore GetByKey(int userId, int storeId);

    }
}
