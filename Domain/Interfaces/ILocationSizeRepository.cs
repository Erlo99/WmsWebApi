using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILocationSizeRepository
    {
        LocationSize GetById(int id);
        IEnumerable<LocationSize> GetWithFilters(string Category = null, string SizeName = null, int? quantity = null );
        void Update(LocationSize locationSize);
        LocationSize Create(LocationSize locationSize);
        void Delete(LocationSize locationSize);
    }
}
