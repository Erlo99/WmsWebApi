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
    class UsersRepository : IUsersRepository
    {
        private readonly WmsContext _context;

        public UsersRepository(WmsContext context)
        {
            _context = context;
        }

        public Users Authenticate(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
            return user;
        }
        public IEnumerable<Users> GetAllWithFilters(ref Pagination pagination, string username = null, RolesEnum? role = null)
        {
            var users = _context.Users.AsEnumerable();

            
            if (username != null)
                users = users.Where(x => x.UserName == username);
            if (role != null)
                users = users.Where(x => x.RoleId == role);

            return PaginationHandler.Page<Users>(users,ref pagination);
        }


        public Users CreateUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(Users user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void UpdateUser(Users user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        
    }
}
