using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public enum OperationsEnum
    {
        test1,
        test2,
        test3,
    }
    [Table("Operations")]
    public class Operations
    {

        public Operations()
        {

        }

        public Operations(OperationsEnum id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public OperationsEnum Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
