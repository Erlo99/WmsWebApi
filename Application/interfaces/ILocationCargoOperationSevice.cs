using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface ILocationCargoOperationSevice
    {

        IEnumerable<LocationCargoOperationDto> GetAllWithFilters(LocationCargoOperationDto operation = null);

    }
}
