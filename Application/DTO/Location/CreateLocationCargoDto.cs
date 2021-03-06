
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
    public class CreateLocationCargoDto : LocationCargoDto, IMap
    {
        public int Id { get; set; }
        public new void Mapping(Profile profile)
        {
            profile.CreateMap<CreateLocationCargoDto,LocationCargo>();
            profile.CreateMap<LocationCargo, CreateLocationCargoDto>();
        }
    }
}
