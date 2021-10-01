using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public enum OperationEnum
    {
        AddCargo,
        RemoveCargo,

    }
    [Table("Operations")]
    public class Operation
    {

        public Operation()
        {

        }

        public Operation(OperationEnum id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public OperationEnum Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
