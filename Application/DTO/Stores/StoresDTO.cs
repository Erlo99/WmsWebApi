using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class StoresDTO : StoreCreateDto, IMap
    {
        public int Id { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<Stores,StoresDTO>();
        }
    }
}
