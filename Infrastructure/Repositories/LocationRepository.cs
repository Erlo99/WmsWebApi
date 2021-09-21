using Application.Middleware;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly WmsContext _context;

        public LocationRepository(WmsContext context)
        {
            _context = context;
        }

        public Locations Create(Locations location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
            return location;
        }

        public IEnumerable<Locations> GetAllWithFilters(ref Pagination pagination, int storeId, string column = null, int? row = null)
        {

            var locations = _context.Locations.Where(x => x.StoreId == storeId).AsEnumerable();


            if (column != null)
                locations.Where(x => x.Column == column);
            if (row != null)
                locations.Where(x => x.Row == row);

            return PaginationHandler.Page<Locations>(locations, ref pagination);
        }

        public Locations GetById(int locationId)
        {
            return _context.Locations.SingleOrDefault(x => x.Id == locationId);
        }

        public void Remove(int locationId)
        {
            var locationToRemove = GetById(locationId);
            _context.Locations.Remove(locationToRemove);
            _context.SaveChanges();
        }

        public void Update(Locations location)
        {
            _context.Locations.Update(location);
            _context.SaveChanges();
        }
    }
}
