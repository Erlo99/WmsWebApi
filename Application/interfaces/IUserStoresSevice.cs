using Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface IUserStoresSevice
    {
        IEnumerable<UserStoresDto> GetAllWithFilters(int? userId = null, int? storeId = null);

        UserStoresDto Create(UserStoresCreateDto userStore);

        void Delete(int userId, int StoreId);
    }
}
