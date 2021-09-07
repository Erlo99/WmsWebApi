using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStoresRepository
    {
        Stores GetById(int id);
        IEnumerable<Stores> GetWithFilters(ref Pagination pagination, bool? isActive = null, bool? isDefault = null);
        void Update(Stores store);
        Stores Create(Stores store);
        void Delete(int id);
    }
}
