using Application.DTO;
using Application.DTO.Users;
using Application.Entities;
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
        public IEnumerable<UsersDto> GetAllWithFilters(int? id = null, string username = null, RolesEnum? role = null)
        {
            var users = _usersRepository.GetAllWithFilters(id, username, role);

            return _mapper.Map<IEnumerable<UsersDto>>(users);
        }

        public UsersDto CreateUser(CreateUsersDto userData)
        {
            var post = _mapper.Map<Users>(userData);
            _usersRepository.CreateUser(post);
            return _mapper.Map<UsersDto>(post);
        }

        public void DeleteUser(int id)
        {
            var user = _usersRepository.GetAllWithFilters(id).ToList().First();
            _usersRepository.DeleteUser(user);
        }

        public void UpdateUser(int id, UpdateUsersDTO userData)
        {
            var existingUser = _usersRepository.GetAllWithFilters(id).ToList().First();
            var user = _mapper.Map(userData, existingUser);
            _usersRepository.UpdateUser(user);
        }
    }
}
