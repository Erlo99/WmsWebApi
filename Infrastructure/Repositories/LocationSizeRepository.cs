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
    public class LocationSizeRepository : ILocationSizeRepository
    {
        private readonly WmsContext _context;

        public LocationSizeRepository(WmsContext context)
        {
            _context = context;
        }

        public LocationSize Create(LocationSize locationSize)
        {
            _context.LocationSizes.Add(locationSize);
            _context.SaveChanges();
            return locationSize;
        }

        public void Delete(LocationSize locationSize)
        {
            _context.LocationSizes.Remove(locationSize);
            _context.SaveChanges();
        }

        public LocationSize GetById(int id)
        {
            return _context.LocationSizes.SingleOrDefault(x => x.Id == id);

        }

        public IEnumerable<LocationSize> GetWithFilters(string category = null, string sizeName = null, int? quantity = null)
        {
            var locationSizes = _context.LocationSizes.AsEnumerable();
            if (category != null)
                locationSizes = locationSizes.Where(x => x.Category == category);
            if (sizeName != null)
                locationSizes = locationSizes.Where(x => x.SizeName == sizeName);
            if (quantity != null)
                locationSizes = locationSizes.Where(x => x.Qty == quantity);
            return locationSizes;
        }

        public void Update(LocationSize locationSize)
        {
            _context.Update(locationSize);
            _context.SaveChanges();
        }
    }
}
