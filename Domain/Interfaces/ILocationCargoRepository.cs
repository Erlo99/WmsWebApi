using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILocationCargoRepository
    {
        IEnumerable<LocationCargo> GetAllWithFilters(int? LocationId = null, int? barcode = null);
        LocationCargo Create(LocationCargo locationCargo);
        void Update(LocationCargo locationCargo); 
    }
}
