using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Views
{
    public class UserOperationsView
    {
        public UserOperationsView()
        {

        }
        public UserOperationsView(string userName, string operationName, string locationName, string details, DateTime operationDate, string storeName)
        {
            UserName = userName;
            OperationName = operationName;
            LocationName = locationName;
            Details = details;
            OperationDate = operationDate;
            StoreName = storeName;
        }

        public string UserName { get; set; }
        public string OperationName { get; set; }
        public string LocationName { get; set; }
        public string Details { get; set; }
        public DateTime OperationDate { get; set; }
        public string StoreName { get; set; }
    }
}
