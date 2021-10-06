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
    public class LocationCargoRepository : ILocationCargoRepository
    {

        private readonly WmsContext _context;

        public LocationCargoRepository(WmsContext context)
        {
            _context = context;
        }

        public LocationCargo Create(LocationCargo locationCargo)
        {
            _context.LocationCargos.Add(locationCargo);
            _context.SaveChanges();
            return locationCargo;
        }

        public void Delete(LocationCargo locationCargo)
        {
            _context.LocationCargos.Remove(locationCargo);
            _context.SaveChanges();
        }

        public IEnumerable<LocationCargo> GetAllWithFilters(int? locationId = null, int? barcode = null)
        {
            
            var locationCargos = _context.LocationCargos.AsEnumerable();
            if (locationId != null)
                locationCargos = locationCargos.Where(x => x.LocationId == locationId);
            if (barcode != null)
                locationCargos = locationCargos.Where(x => x.Barcode == barcode);

            return locationCargos;
        }

        public void Update(LocationCargo locationCargo)
        {
            _context.LocationCargos.Update(locationCargo);
            _context.SaveChanges();
        }
    }
}
