using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface ILocationSizesService
    {
        LocationSizeDto GetById(int id);
        IEnumerable<LocationSizeDto> GetWithFilters(string Category = null, string SizeName = null, int? quantity = null);
        void Update(LocationSizeDto store);
        LocationSizeDto Create(LocationSizeDto store);
        void Delete(int id);
    }
}
