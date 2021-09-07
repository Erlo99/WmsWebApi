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
    public class CargosDto : IMap
    {
        public int Barcode { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Cargos, CargosDto>();
            profile.CreateMap<CargosDto, Cargos>();
        }
    }
}
