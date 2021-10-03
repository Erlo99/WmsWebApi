﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILocationCargoOperationRepository
    {
        IEnumerable<LocationCargoOperation> GetAllWithFilters(ref Pagination pagination, LocationCargoOperation? operation = null);
        void AddOperation(LocationCargoOperation operation); 
    }
}
