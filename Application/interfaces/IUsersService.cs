using Application.DTO;
using Application.DTO.Users;
using Application.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface IUsersService
    {
        public IEnumerable<UsersDto> GetAllWithFilters(int? id = null, string username = null, RolesEnum? role = null);

        public UsersDto Authenticate(string username, string password);

        public void UpdateUser(int id, UpdateUsersDTO user);

        public UsersDto CreateUser(CreateUsersDto user);

        public void DeleteUser(int id);

    }
}
