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
    public class StoreRepository : IStoreRepository
    {
        private readonly WmsContext _context;

        public StoreRepository(WmsContext context)
        {
            _context = context;
        }

        public Store Create(Store store)
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

        public Store GetById(int id)
        {
            return _context.Stores.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Store> GetWithFilters( bool? isActive = null, bool? isDefault = null, string name = null)
        {
            var stores = _context.Stores.AsEnumerable();
            
            if (isActive != null)
                stores = stores.Where(x => x.IsActive == isActive);
            if (isDefault != null)
                stores = stores.Where(x => x.IsDefault == isDefault);
            if (name != null)
                stores = stores.Where(x => x.Name == name);

            return stores;
            }

        public void Update(Store store)
        {
            _context.Stores.Update(store);
            _context.SaveChanges();
        }
    }
}
