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
    public class LocationCargoOperationDto : IMap
    {
        public OperationEnum? OperationId { get; set; }
        public int? UserId { get; set; }
        public int? Barcode { get; set; }
        public int? Qty { get; set; }
        public int? LocationId { get; set; }
        public DateTime? CreateAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LocationCargoOperation, LocationCargoOperationDto>();
            profile.CreateMap<LocationCargoOperationDto, LocationCargoOperation>();
        }
    }
}
