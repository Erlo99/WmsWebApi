using Application.DTO;

using Application.DTO.Locations;
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
        IEnumerable<LocationDto> GetWithFilters(int? storeId = null, string column = null, int? row = null);
        void Update(int locationId, CreateLocationDto store);
        LocationDto Create(CreateLocationDto store);
        void Delete(int id);

        void ValidateAccess(int id);

        void ValidateDto(ref CreateLocationDto location);

    }
}
