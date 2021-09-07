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
    [Table("UserStores")]
    public class UserStores : AuditableEntity
    {
        public UserStores()
        {

        }
        
        public UserStores(int userId, Users.Users users, int storeId, Stores stores)
        {
            UserId = userId;
            Users = users;
            StoreId = storeId;
            Stores = stores;
        }

        //[Key]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual Entities.Users.Users Users { get; set; }
        [ForeignKey("Stores")]
        public int StoreId { get; set; }
        public virtual Stores Stores { get; set; }
    }
}
