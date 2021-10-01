using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("LocationCargoOperation")]
    public class LocationCargoOperation
    {
        [Key]
        public int Id { get; set; }
        public OperationEnum OperationId { get; set; }
        public int UserId { get; set; }


    }
}
