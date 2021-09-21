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

        Users GetById(int id);
        Users GetByUsername(string username);

        //void UpdateUser()

        Users CreateUser(Users user);
        void DeleteUser(Users id);

        void UpdateUser(Users users);
    }
}
