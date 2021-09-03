using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities.Users
{
    [Table("Users")]
    public class Users : AuditableEntity
    {

        public Users()
        {

        }


        public Users(int id, string firstName, string lastName, string userName, string password, RolesEnum roleId, Roles roles)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            RoleId = roleId;
            Roles = roles;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [ForeignKey("Roles")]
        [Required]
        public RolesEnum RoleId { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
