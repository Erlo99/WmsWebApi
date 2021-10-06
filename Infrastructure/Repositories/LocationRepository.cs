using Application.Middleware;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly WmsContext _context;

        public LocationRepository(WmsContext context)
        {
            _context = context;
        }

        public Location Create(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
            return location;
        }

        public List<int> GetAllLocationsForUserStores(List<int> locationIds, List<int> storeIds)
        {
            var userLocationIds = _context.Locations.Where(x => storeIds.Contains(x.StoreId)).Select(x => x.Id ).AsEnumerable();
            var validLocationIds = userLocationIds.Intersect(locationIds).ToList();
            return validLocationIds;
        }

        public IEnumerable<Location> GetAllWithFilters(int? storeId = null, string column = null, int? row = null)
        {

            var locations = _context.Locations.AsEnumerable();
            if (storeId != null)
                locations = locations.Where(x => x.StoreId == storeId);
            if (column != null)
                locations = locations.Where(x => x.Column == column);
            if (row != null)
                locations = locations.Where(x => x.Row == row);

            return locations;
        }

        public Location GetById(int locationId)
        {
            return _context.Locations.SingleOrDefault(x => x.Id == locationId);
        }

        public void Remove(Location location)
        {
            _context.Locations.Remove(location);
            _context.SaveChanges();
        }

        public void Update(Location location)
        {
            _context.Locations.Update(location);
            _context.SaveChanges();
        }
    }
}
