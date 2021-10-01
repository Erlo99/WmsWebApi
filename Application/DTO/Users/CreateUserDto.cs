using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deu = Domain.Entities.Users;

namespace Application.DTO.Users
{
    public class CreateUserDto : UpdateUserDto
    {

        public string Password { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, deu.User>();
        }
    }
}
