﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public enum RoleEnum
    {
        SuperAdmin = 0,
        Admin = 1,
        Manager = 2,
        Worker = 3,
        Accountant = 4,
    }
    [Table("Roles")]
    public class Role
    {

        public Role()
        {

        }
        public Role(RoleEnum roleId, string name)
        {
            Id = roleId;
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public RoleEnum Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
