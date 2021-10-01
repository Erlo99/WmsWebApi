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
    public class CargoDto : IMap
    {
        public int Barcode { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Cargo, CargoDto>();
            profile.CreateMap<CargoDto, Cargo>();
        }
    }
}
