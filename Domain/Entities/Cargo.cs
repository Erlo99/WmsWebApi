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
    [Table("Cargos")]
    public class Cargo : AuditableEntity
    {
        public Cargo()
        {

        }
        public Cargo(int barcode, string sku, string name)
        {
            Barcode = barcode;
            Sku = sku;
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Barcode { get; set; }
        [Required]
        [MaxLength(50)]
        public string Sku { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
