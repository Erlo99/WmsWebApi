using Application.DTO;
using Application.DTO.Users;
using Application.Entities;
using Application.Helpers;
using Domain.Entities;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface IUsersService
    {
        public (IEnumerable<UsersDto>, PagedDto) GetAllWithFilters(ref PaginationDto pagination, string username = null, RolesEnum? role = null);

        public UsersDto GetById(int id);
        public UsersDto GetCurrentUser();

        public bool CanCurrentUserManipulateData(Users existingUser, Users modifiedUser = null);


        public void UpdateUser(int id, UpdateUsersDTO user);

        public UsersDto CreateUser(CreateUsersDto user);

        public void DeleteUser(int id);

    }
}
