using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILocationCargosRepository
    {
        IEnumerable<LocationCargos> GetAllWithFilters(int? LocationId = null, int? barcode = null);
        LocationCargos Create(LocationCargos locationCargo);
        void Update(LocationCargos locationCargo); 
    }
}
