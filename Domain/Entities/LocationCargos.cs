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
    [Table("LocationCargos")]
    public class LocationCargos : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Locations")]
        public int LocationId { get; set; }
        [Required]
        [ForeignKey("Cargos")]
        public int Barcode { get; set; }
        [Required]
        public int Qty { get; set; }

        public virtual Locations Locations { get; set; }
        public virtual Cargos Cargos { get; set; }

    }
}
