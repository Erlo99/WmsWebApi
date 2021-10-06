using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface ILocationCargoService
    {
            IEnumerable<LocationCargoDto> GetAllWithFilters(int? locationId = null, int? barcode = null);
            CreateLocationCargoDto Create(LocationCargoDto locationCargo);
            void Update(LocationCargoDto locationCargo);
    }
}
