using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Locations
{
    public class CreateLocationDto : IMap
    {
        public int StoreId { get; set; }
        public string Column { get; set; }
        public int Row { get; set; }
        public int SizeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateLocationDto, Location>();
            profile.CreateMap<Location, CreateLocationDto>();
        }
    }
}
