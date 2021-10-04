﻿using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface ILocationSizeService
    {
        LocationSizeDto GetById(int id);
        IEnumerable<LocationSizeDto> GetWithFilters(string Category = null, string SizeName = null, int? quantity = null);
        void Update(int id, CreateLocationSizeDto store);
        LocationSizeDto Create(CreateLocationSizeDto store);
        void Delete(int id);
    }
}
