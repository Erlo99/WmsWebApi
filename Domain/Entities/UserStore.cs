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
    public class UserStore : AuditableEntity
    {
        public UserStore()
        {

        }
        
        public UserStore(int userId, Users.User users, int storeId, Store stores)
        {
            UserId = userId;
            Users = users;
            StoreId = storeId;
            Stores = stores;
        }

        //[Key]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual Entities.Users.User Users { get; set; }
        [ForeignKey("Stores")]
        public int StoreId { get; set; }
        public virtual Store Stores { get; set; }
    }
}
