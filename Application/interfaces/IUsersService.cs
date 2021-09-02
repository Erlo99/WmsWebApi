using Application.DTO;
using Application.DTO.Users;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface IUsersService
    {
        public IEnumerable<UsersDto> GetAllUsers();
        public UsersDto GetUserByFilters(int Id);

        public UsersDto Authenticate(string username, string password);

        public void UpdateUser();
    }
}
