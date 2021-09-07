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
    public class CargosRepository : ICargosRepository
    {
        private readonly WmsContext _context;


        public Cargos Create(Cargos cargo)
        {
            _context.Cargos.Add(cargo);
            _context.SaveChanges();
            return cargo;
        }

        public void Delete(int barcode)
        {
            var cargo = _context.Cargos.SingleOrDefault(x => x.Barcode == barcode);
            _context.Cargos.Remove(cargo);
            _context.SaveChanges();
        }


        public IEnumerable<Cargos> GetWithFilters(ref Pagination pagination, int? barcode = null, string sku = null, string name = null)
        {
            var cargos = _context.Cargos.AsEnumerable();

            if (barcode != null)
                cargos.Where(x => x.Barcode == barcode);
            if (sku != null)
                cargos.Where(x => x.Sku == sku);
            if (name != null)
                cargos.Where(x => x.Name == name);

            return PaginationHandler.Page(cargos, ref pagination);
            }

        public void Update(Cargos store)
        {
            _context.Cargos.Update(store);
            _context.SaveChanges();
        }
    }
}
