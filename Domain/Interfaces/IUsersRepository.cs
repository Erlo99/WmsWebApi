using Domain.Entities;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetAllWithFilters(ref Pagination pagination, string username = null, RolesEnum? role = null);

        

        //void UpdateUser()
        Users Authenticate(string username, string password);

        Users CreateUser(Users user);
        void DeleteUser(Users id);

        void UpdateUser(Users users);
    }
}
