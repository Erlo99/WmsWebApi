using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class RoleDto
    {
        public RolesEnum RoleId { get; set; }
        public string Name { get; set; }
    }
}
