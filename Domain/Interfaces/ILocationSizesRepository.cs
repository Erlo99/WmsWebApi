﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILocationSizesRepository
    {
        LocationSize GetById(int id);
        IEnumerable<LocationSize> GetWithFilters(string Category = null, string SizeName = null, int? quantity = null );
        void Update(LocationSize store);
        LocationSize Create(LocationSize store);
        void Delete(int id);
    }
}
