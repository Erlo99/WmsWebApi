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
    [Table("LocationSize")]
    public class LocationSize : AuditableEntity
    {

        public LocationSize()
        {

        }
        public LocationSize(int id, string sizeName, string category, int width, int height, int length, int qty)
        {
            Id = id;
            SizeName = sizeName;
            Category = category;
            Width = width;
            Height = height;
            Length = length;
            Qty = qty;
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string SizeName { get; set; }
        [MaxLength(10)]
        [Required]
        public string Category { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        [Required]
        public int Qty { get; set; }

    }
}
