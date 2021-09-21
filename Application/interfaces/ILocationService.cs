using Application.DTO;
using Application.DTO.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface ILocationService
    {
        LocationDto GetById(int id);
        (IEnumerable<LocationDto>, PagedDto) GetWithFilters(ref PaginationDto pagination, int storeId, string column = null, int? row = null);
        void Update(int locationId, LocationDto store);
        CreateLocationsDto Create(LocationDto store);
        void Delete(int id);

    }
}
