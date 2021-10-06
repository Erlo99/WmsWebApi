using Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface IUserStoreService
    {
        IEnumerable<UserStoreDto> GetAllWithFilters(int? userId = null, int? storeId = null);

        UserStoreDto Create(CreateUserStoreDto userStore);

        void Delete(int userId, int StoreId);

        void InsertDefaultStoresToUser(int userId);
        void ValidateAccess(int storeId, int userId);
    }
}
