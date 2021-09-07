using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("UserOperations")]
    public class UserOperations
    {
        public UserOperations()
        {

        }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("Operations")]
        public int OperationId { get; set; }
        public int LocationId { get; set; }
        [MaxLength(500)]
        public string Details { get; set; }
        public DateTime OperationDate { get; set; }

        public virtual OperationsEnum Operations { get; set; }
    }
}
