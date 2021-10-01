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
    public class LocationCargo : AuditableEntity
    {
        public LocationCargo()
        {

        }
        public LocationCargo(int id, int locationId, int barcode, int qty, Location locations, Cargo cargos)
        {
            Id = id;
            LocationId = locationId;
            Barcode = barcode;
            Qty = qty;
            Locations = locations;
            Cargos = cargos;
        }

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

        public virtual Location Locations { get; set; }
        public virtual Cargo Cargos { get; set; }

    }
}
