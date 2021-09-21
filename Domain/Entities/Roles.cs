using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public enum RolesEnum
    {
        SuperAdmin = 0,
        Admin = 1,
        Manager = 2,
        Worker = 3,
        Accountant = 4,
    }
    [Table("Roles")]
    public class Roles
    {

        public Roles()
        {

        }
        public Roles(RolesEnum roleId, string name)
        {
            Id = roleId;
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public RolesEnum Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
