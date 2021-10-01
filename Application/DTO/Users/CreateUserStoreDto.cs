using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Users
{
    public class CreateUserStoreDto : IMap
    {
        public int UserId { get; set; }
        public int StoreId { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserStoreDto, UserStore>();
        }
    }
}
