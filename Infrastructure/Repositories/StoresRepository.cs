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
    public class StoresRepository : IStoresRepository
    {
        private readonly WmsContext _context;

        public StoresRepository(WmsContext context)
        {
            _context = context;
        }

        public Stores Create(Stores store)
        {
            _context.Stores.Add(store);
            _context.SaveChanges();
            return store;
        }

        public void Delete(int id)
        {
            _context.Stores.Remove(GetById(id));
            _context.SaveChanges();
        }

        public Stores GetById(int id)
        {
            return _context.Stores.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Stores> GetWithFilters(ref Pagination pagination, bool? isActive = null, bool? isDefault = null)
        {
            var stores = _context.Stores.AsEnumerable();

            if (isActive != null)
                stores.Where(x => x.IsActive == isActive);
            if (isDefault != null)
                stores.Where(x => x.IsDefault == isDefault);

            return PaginationHandler.Page(stores, ref pagination);
            }

        public void Update(Stores store)
        {
            _context.Stores.Update(store);
            _context.SaveChanges();
        }
    }
}
