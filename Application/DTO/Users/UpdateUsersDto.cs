using Application.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deu = Domain.Entities.Users;

namespace Application.DTO.Users
{
    public class UpdateUsersDTO : IMap
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }


        public virtual void  Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUsersDTO, deu.Users>();
        }
    }
}
