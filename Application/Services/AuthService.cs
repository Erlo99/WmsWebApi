using Application.DTO.Users;
using Application.Helpers;
using Application.interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _usersRepository;
        private readonly IMapper _mapper;

        public AuthService(IAuthRepository authRepository, IUserRepository usersRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public UserDto Authenticate(string username, string password)
        {
            
            var user = _usersRepository.GetAllWithFilters(username).SingleOrDefault();
            if(BC.Verify(password, user.Password))
                return _mapper.Map<UserDto>(user);
            throw new BadRequestException("Incorrect username or password");
        }
    }
}
