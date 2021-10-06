using Application.DTO;
using Application.DTO.Users;
using Application.Entities;
using Application.Helpers;
using Application.interfaces;
using Application.Middleware;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Users;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Application.Services
{
    class UserService : IUserService
    {

        private readonly IUserRepository _usersRepository;
        private readonly IUserStoreRepository _userStoresRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository usersRepository, IMapper mapper, IUserStoreRepository userStoresRepository)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
            _userStoresRepository = userStoresRepository;
        }

        public UserDto GetById(int id)
        {
            var user = ValidateAccess(id);
            return _mapper.Map<UserDto>(user);
        }
        public UserDto GetCurrentUser()
        {
            var user = _usersRepository.GetById(HttpContext.GetUserId());
            return _mapper.Map<UserDto>(user);
        }

        public IEnumerable<UserDto> GetAllWithFilters(string username = null, RolesEnum? role = null)
        {
            var users = _usersRepository.GetAllWithFilters(username, role);
            if (username != null)
                ValidateAccess(users.SingleOrDefault().Id);
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public UserDto CreateUser(CreateUserDto userData)
        {
            var user = _mapper.Map<User>(userData);
            if (!HttpContext.CanCurrentUserUpdate(user))
                throw new BadRequestException(ResponseMessage.BadRequestForId);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user = _usersRepository.CreateUser(user);
            _userStoresRepository.InsertDefaultStores(user.Id);
            return _mapper.Map<UserDto>(user);
        }

        public void DeleteUser(int id)
        {
            var user = ValidateAccess(id);
            _usersRepository.DeleteUser(user);
        }

        public void UpdateUser(int id, UpdateUserDto userData)
        {
            var existingUser = ValidateAccess(id);
            var user = _mapper.Map(userData, existingUser);
            _usersRepository.UpdateUser(user);
        }

        public User ValidateAccess(int id)
        {
            var user = _usersRepository.GetById(id);
            if (!HttpContext.CanCurrentUserUpdate(user))
                throw new BadRequestException(ResponseMessage.BadRequestForId);
            return user;
        }
    }
}





//Exclude elements from left collection which exists in right collection without using Linq.You can use any data structures you want.
//Example:
//Input:
//left = { 1,2,2,3,4,4,5,6};
//right = { 2,3};
//result = { 1,4,4,5,6}
//public static IEnumerable<int> Except(IEnumerable<int> left, IEnumerable<int> right)


