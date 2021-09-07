using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("LocationSize")]
    public class LocationSize
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string SizeName { get; set; }
        public int Width { get; set; }
        public int height { get; set; }
        public int Length { get; set; }
        [Required]
        public int Qty { get; set; }

    }
}
