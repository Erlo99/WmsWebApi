using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Views
{
    public class UserStoreView 
    {
        public UserStoreView()
        {

        }
        public UserStoreView(string userName, string storeName, int userId, int storeId)
        {
            UserName = userName;
            StoreName = storeName;
            UserId = userId;
            StoreId = storeId;
        }

        public string UserName { get; set; }
        public string StoreName { get; set; }
        public int UserId { get; set; }
        public int StoreId { get; set; }
    }
}
