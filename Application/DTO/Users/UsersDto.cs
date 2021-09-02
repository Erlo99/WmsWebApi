﻿using Application.Mappings;
using AutoMapper;
using Domain.Common;
using deu = Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Users
{
    public class UsersDto :  IMap
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<deu.Users, UsersDto>();
        }
    }
}
