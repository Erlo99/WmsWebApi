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
    public class CreateLocationSizeDto :  IMap
    {
        public string SizeName { get; set; }
        public string Category { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int Qty { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LocationSize, CreateLocationSizeDto>();
            profile.CreateMap<CreateLocationSizeDto, LocationSize>();
        }
    }
}
