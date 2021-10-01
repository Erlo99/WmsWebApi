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
    public class UserOperationDto : IMap
    {
        public string UserName { get; set; }
        public string OperationName { get; set; }
        public string LocationName { get; set; }
        public string StoreName { get; set; }
        public string Details { get; set; }
        public DateTime OperationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserOperation, UserOperationDto>();
        }
    }
}
