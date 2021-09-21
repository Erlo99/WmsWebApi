using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILocationRepository
    {
        Locations GetById(int locationId);
        IEnumerable<Locations> GetAllWithFilters(ref Pagination pagination,int storeId, string column =null, int? row = null);
        Locations Create(Locations  location);
        void Update(Locations location);

        void Remove(int locationId);
    }
}
