﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    interface IGenericService<TObejct>
    {
        TObejct getById(int id);
    }
}
