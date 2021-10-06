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
        IEnumerable<User> GetAllWithFilters(string username = null, RoleEnum? role = null);
        User GetById(int id);
        User CreateUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
    }
}
