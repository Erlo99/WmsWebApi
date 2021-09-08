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

        public UserOperations(int id, string userName, string operationName, string locationName, string details, DateTime operationDate)
        {
            Id = id;
            UserName = userName;
            OperationName = operationName;
            LocationName = locationName;
            Details = details;
            OperationDate = operationDate;
        }

        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string  OperationName { get; set; }
        public string LocationName { get; set; }
        public string StoreName { get; set; }
        [MaxLength(500)]
        public string Details { get; set; }
        public DateTime OperationDate { get; set; }

    }
}
