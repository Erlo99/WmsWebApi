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
    [Table("Locations")]
    public class Locations : AuditableEntity
    {
        public Locations()
        {

        }
        public Locations(int id, int storeId, string column, int row, int sizeId, Stores stores, LocationSize locationSize)
        {
            Id = id;
            StoreId = storeId;
            Column = column;
            Row = row;
            SizeId = sizeId;
            Stores = stores;
            LocationSize = locationSize;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Stores")]
        public int StoreId { get; set; }
        [Required]
        [MaxLength(2)]
        public string Column { get; set; }
        [Required]
        public int Row { get; set; }
        [Required]
        [ForeignKey("LocationSize")]
        public int SizeId { get; set; }

        public virtual Stores Stores { get; set; }
        public virtual LocationSize LocationSize { get; set; }

    }
}
