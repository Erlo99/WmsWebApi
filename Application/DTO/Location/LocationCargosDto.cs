﻿using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class LocationCargosDto : IMap
    {
        public int LocationId { get; set; }
        public int Barcode { get; set; }
        public int Qty { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LocationCargosDto, LocationCargos>();
            //byc moze drugi trzeba
        }
    }
}
