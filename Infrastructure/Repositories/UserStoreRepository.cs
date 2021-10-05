using Domain.Entities;
using Domain.Entities.Views;
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
    public class UserStoreRepository : IUserStoreRepository
    {
        private readonly WmsContext _context;
        

        public UserStoreRepository(WmsContext context)
        {
            _context = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
        }

        public UserStoreView Create(UserStore store)
        {
            _context.Add(store);
            _context.SaveChanges();
            return _context.userStoresViews.SingleOrDefault(x => x.StoreId == store.StoreId && x.UserId == store.UserId);
        }

        public void Delete(int userId, int storeId)
        {
            var userStore = _context.UserStores.SingleOrDefault( x => x.StoreId == storeId && x.UserId == userId);
            _context.UserStores.Remove(userStore);
            _context.SaveChanges();
        }

        public IEnumerable<UserStoreView> GetAllWithFilters(int? userId = null, int? storeId = null)
        {
            var userStores = _context.userStoresViews.AsEnumerable();

            if (userId != null)
                userStores = userStores.Where(x => x.UserId == userId);
            if (storeId != null)
                userStores = userStores.Where(x => x.StoreId == storeId);
            
            return userStores;
        }

        public UserStore GetByKey(int userId, int storeId)
        {
            return _context.UserStores.SingleOrDefault(x => x.StoreId == storeId && x.UserId == userId);
        }

        public void InsertDefaultStores(int userId)
        {
            var userStores = _context.UserStores.Where(x => x.UserId == userId);
            var defaultStores =  _context.Stores.Where(x => x.IsDefault && x.IsActive && !userStores.Any(us => us.StoreId == x.Id)).AsEnumerable();
            List<UserStore> defaultUserStores = new List<UserStore>();
            foreach (var store in defaultStores)
                defaultUserStores.Add(new UserStore() { UserId = userId, StoreId = store.Id});
            _context.UserStores.AddRange(defaultUserStores);
            _context.SaveChanges();
        }

    }
}
