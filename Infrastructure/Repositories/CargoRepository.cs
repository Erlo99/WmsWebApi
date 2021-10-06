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
    public class CargoRepository : ICargoRepository
    {
        private readonly WmsContext _context;

        public CargoRepository(WmsContext context)
        {
            _context = context;
        }

        public Cargo Create(Cargo cargo)
        {
            _context.Cargos.Add(cargo);
            _context.SaveChanges();
            return cargo;
        }

        public void Delete(Cargo cargo)
        {
            _context.Cargos.Remove(cargo);
            _context.SaveChanges();
        }

        public Cargo GetByBarcode(int barcode)
        {
           return  _context.Cargos.SingleOrDefault(x => x.Barcode == barcode);
        }

        public IEnumerable<Cargo> GetWithFilters( int? barcode = null, string sku = null, string name = null)
        {
            var cargos = _context.Cargos.AsEnumerable();

            if (barcode != null)
                cargos = cargos.Where(x => x.Barcode == barcode);
            if (sku != null)
                cargos = cargos.Where(x => x.Sku == sku);
            if (name != null)
                cargos = cargos.Where(x => x.Name == name);

            return cargos;
            }

        public void Update(Cargo store)
        {
            _context.Cargos.Update(store);
            _context.SaveChanges();
        }
    }
}
