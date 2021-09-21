﻿using Application.DTO.Users;
using Domain.Entities.Users;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly WmsContext _context;

        public AuthRepository(WmsContext context)
        {
            _context = context;
        }

        public Users Authenticate(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
            return user;
        }
    }
}
