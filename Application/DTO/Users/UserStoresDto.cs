using Application.Mappings;
using AutoMapper;
using Domain.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Users
{
    public class UserStoresDto : UserStoresCreateDto, IMap
    {
        public string UserName {get; set;}
        public string StoreName { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<UserStoresView, UserStoresDto>();
                //.ForMember(x =>
               //x.StoreName, opt => opt.MapFrom( src => src.StoreId)
            //);
        }
    }
}
