using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Stores")]
    public class Stores : AuditableEntity
    {
        public Stores()
        {

        }

        public Stores(int id, string name, bool isActive, bool isDefault)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
            IsDefault = isDefault;
        }

        [Key]
        public int Id { get; set; }   
        [MaxLength(100)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
    }
}
