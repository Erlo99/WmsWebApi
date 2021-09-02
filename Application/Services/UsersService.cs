using Application.DTO;
using Application.DTO.Users;
using Application.Entities;
using Application.interfaces;
using AutoMapper;
using Domain.Interfaces;
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

        public IEnumerable<UsersDto> GetAllUsers()
        {
            var users = _usersRepository.GetAll();
            return _mapper.Map<IEnumerable<UsersDto>>(users);
        }

        public UsersDto GetUserByFilters(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser()
        {
            throw new NotImplementedException();
        }

    }
}
