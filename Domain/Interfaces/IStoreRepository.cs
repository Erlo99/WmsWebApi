﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStoreRepository
    {
        Store GetById(int id);
        IEnumerable<Store> GetWithFilters(ref Pagination pagination, bool? isActive = null, bool? isDefault = null);
        void Update(Store store);
        Store Create(Store store);
        void Delete(int id);
    }
}
