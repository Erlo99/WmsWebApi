using Domain.Entities;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllWithFilters(string username = null, RolesEnum? role = null);

        User GetById(int id);
        User GetByUsername(string username);

        //void UpdateUser()

        User CreateUser(User user);
        void DeleteUser(User id);

        void UpdateUser(User users);
    }
}
