using Application.DTO;
using Application.Middleware;
using Domain.Entities;
using Domain.Entities.Users;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly WmsContext _context;

        public UserRepository(WmsContext context)
        {
            _context = context;
        }



        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == username);
        }

        public IEnumerable<User> GetAllWithFilters(string username = null, RolesEnum? role = null)
        {
            var users = _context.Users.AsEnumerable();

            if (username != null)
                users = users.Where(x => x.UserName == username);
            if (role != null)
                users = users.Where(x => x.RoleId == role);

            return users;
        }


        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

    }
}
