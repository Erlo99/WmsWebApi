﻿using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Location
{
    public class LocationDto : IMap
    {
        public int StoreId { get; set; }
        public string Column { get; set; }
        public int Row { get; set; }
        public int SizeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LocationDto, Locations>();
        }
    }
}
