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
        Admin = 0,
        Manager = 1,
        Worker = 2,
        Accountant = 3
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
