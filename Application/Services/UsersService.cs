using Application.DTO;
using Application.DTO.Users;
using Application.Entities;
using Application.Helpers;
using Application.interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Users;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    class UsersService : IUsersService
    {

        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public UsersDto Authenticate(string username, string password)
        {
            var user = _usersRepository.Authenticate(username, password);

            return _mapper.Map<UsersDto>(user);
        }


        public UsersDto GetById(int id)
        {
            var user =_usersRepository.GetById(id);
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
            var post = _mapper.Map<Users>(userData);
            _usersRepository.CreateUser(post);
            return _mapper.Map<UsersDto>(post);
        }

        public void DeleteUser(int id)
        {
            var user = _usersRepository.GetById(id);
            _usersRepository.DeleteUser(user);
        }

        public void UpdateUser(int id, UpdateUsersDTO userData)
        {
            var existingUser = _usersRepository.GetById(id);
            var user = _mapper.Map(userData, existingUser);
            _usersRepository.UpdateUser(user);
        }

    }
}
