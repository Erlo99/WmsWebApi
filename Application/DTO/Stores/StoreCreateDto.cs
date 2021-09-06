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
    public class StoreCreateDto : IMap
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<StoreCreateDto,Stores>();
        }
    }
}
