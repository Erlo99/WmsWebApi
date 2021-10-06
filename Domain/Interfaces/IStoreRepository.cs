using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStoreRepository
    {
        Store GetById(int id);
        IEnumerable<Store> GetWithFilters( bool? isActive = null, bool? isDefault = null, string name = null);
        void Update(Store store);
        Store Create(Store store);
        void Delete(Store id);
    }
}
