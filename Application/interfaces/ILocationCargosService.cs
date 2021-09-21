using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface ILocationCargosService
    {
            IEnumerable<LocationCargosDto> GetAllWithFilters(int? locationId = null, int? barcode = null);
            CreateLocationCargosDto Create(LocationCargosDto locationCargo);
            void Update(int locationId, int barcode, LocationCargosDto locationCargo);
        
    }
}
