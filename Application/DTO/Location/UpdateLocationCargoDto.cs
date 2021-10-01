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
    public class UpdateLocationCargoDto : IMap
    {
        public int Qty { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateLocationCargoDto, LocationCargo>();
        }
    }
}
