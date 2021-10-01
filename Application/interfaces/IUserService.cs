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
    public interface IUserService
    {
        public (IEnumerable<UserDto>, PagedDto) GetAllWithFilters(ref PaginationDto pagination, string username = null, RolesEnum? role = null);

        public UserDto GetById(int id);
        public UserDto GetCurrentUser();

        public bool CanCurrentUserManipulateData(User existingUser, User modifiedUser = null);


        public void UpdateUser(int id, UpdateUserDto user);

        public UserDto CreateUser(CreateUserDto user);

        public void DeleteUser(int id);

    }
}
