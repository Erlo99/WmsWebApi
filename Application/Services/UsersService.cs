using Application.DTO;
using Application.DTO.Users;
using Application.Entities;
using Application.Helpers;
using Application.interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Users;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Application.Services
{
    class UsersService : IUsersService
    {

        private readonly IUsersRepository _usersRepository;
        private readonly IUserStoresRepository _userStoresRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersService(IUsersRepository usersRepository, IMapper mapper, IUserStoresRepository userStoresRepository, IHttpContextAccessor httpContextAccessor)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userStoresRepository = userStoresRepository;
        }

       

        public bool CanCurrentUserManipulateData(Users existingUser, Users modifiedUser = null)
        {
            
            ClaimsIdentity identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            return CheckUserRoles.CanCurrentUserUpdate(identity, existingUser, modifiedUser);
        }


        public UsersDto GetById(int id)
        {
            var user = _usersRepository.GetById(id);
            if (user == null || !CanCurrentUserManipulateData(user))
               throw new BadRequestException(ResponseMessage.BadRequestForId);
            return _mapper.Map<UsersDto>(user);
        }
        public UsersDto GetCurrentUser()
        {
            var user = _usersRepository.GetByUsername(_httpContextAccessor.HttpContext.User.Identity.Name);
            return _mapper.Map<UsersDto>(user);
        }

        public (IEnumerable<UsersDto>, PagedDto) GetAllWithFilters(ref PaginationDto paginationData, string username = null, RolesEnum? role = null)
        {
            Pagination pagination = _mapper.Map<Pagination>(paginationData);
            var users = _usersRepository.GetAllWithFilters(ref pagination, username, role);
            var paged = _mapper.Map<PagedDto>(pagination);
            return (_mapper.Map<IEnumerable<UsersDto>>(users), paged);
        }

        public UsersDto CreateUser(CreateUsersDto userData)
        {
            var user = _mapper.Map<Users>(userData);
            if (user == null || !CanCurrentUserManipulateData(user))
                throw new BadRequestException(ResponseMessage.BadRequestForId);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user = _usersRepository.CreateUser(user);
            _userStoresRepository.InsertDefaultStores(user.Id);
            return _mapper.Map<UsersDto>(user);
        }

        public void DeleteUser(int id)
        {
                var user = _usersRepository.GetById(id);
                if (user == null || !CanCurrentUserManipulateData(user))
                    throw new BadRequestException(ResponseMessage.BadRequestForId);
                _usersRepository.DeleteUser(user);
        }

        public void UpdateUser(int id, UpdateUsersDTO userData)
        {
            var existingUser = _usersRepository.GetById(id);
            if (existingUser == null || !CanCurrentUserManipulateData(existingUser, _mapper.Map<Users>(userData)))
                throw new BadRequestException(ResponseMessage.BadRequestForId);
            var user = _mapper.Map(userData, existingUser);
            _usersRepository.UpdateUser(user);
        }

    }
}
