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
        Location GetById(int locationId);
        IEnumerable<Location> GetAllWithFilters(int? storeId = null, string column =null, int? row = null);
        Location Create(Location  location);
        void Update(Location location);
        List<int> GetAllLocationsForUserStores(List<int> locationIds, List<int> storeIds);
        void Remove(Location location);
    }
}
