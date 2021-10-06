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
        private readonly IUserStoreRepository _userStoreRepository;

        public LocationRepository(WmsContext context, IUserStoreRepository userStoreRepository)
        {
            _context = context;
            _userStoreRepository = userStoreRepository;
        }

        public Location Create(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
            return location;
        }

        public IEnumerable<Location> GetAllWithFilters(int? storeId = null, string column = null, int? row = null)
        {

            var locations = _context.Locations.AsEnumerable();
            if (column != null)
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

        public void Remove(int locationId)
        {
            var locationToRemove = GetById(locationId);
            _context.Locations.Remove(locationToRemove);
            _context.SaveChanges();
        }

        public void Update(Location location)
        {
            _context.Locations.Update(location);
            _context.SaveChanges();
        }
    }
}
