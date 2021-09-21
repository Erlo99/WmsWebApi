using Application.DTO.Users;
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
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;

        public AuthService(IAuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }

        public UsersDto Authenticate(string username, string password)
        {
            var user = _authRepository.Authenticate(username, password);
            return _mapper.Map<UsersDto>(user);
        }
    }
}
