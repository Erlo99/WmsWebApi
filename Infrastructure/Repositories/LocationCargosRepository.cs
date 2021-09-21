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
    public class LocationCargosRepository : ILocationCargosRepository
    {

        private readonly WmsContext _context;

        public LocationCargosRepository(WmsContext context)
        {
            _context = context;
        }

        public LocationCargos Create(LocationCargos locationCargo)
        {
            _context.Add(locationCargo);
            _context.SaveChanges();
            return locationCargo;
        }

        public IEnumerable<LocationCargos> GetAllWithFilters(int? locationId = null, int? barcode = null)
        {
            var locationCargos = _context.LocationCargos.AsEnumerable();
            if (locationId == null)
                locationCargos.Where(x => x.LocationId == locationId);
            if (barcode == null)
                locationCargos.Where(x => x.Barcode == barcode);

            return locationCargos;
        }

        public void Update(LocationCargos locationCargo)
        {
            _context.Update(locationCargo);
            _context.SaveChanges();
        }
    }
}
