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
        CreateLocationDto GetById(int id);
        IEnumerable<CreateLocationDto> GetWithFilters(int? storeId = null, string column = null, int? row = null);
        void Update(int locationId, LocationDto store);
        CreateLocationDto Create(LocationDto store);
        void Delete(int id);

        void ValidateAccess(int id);

        void ValidateDto(ref LocationDto location);

    }
}
