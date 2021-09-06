using Application.interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenericService<TObject> : IGenericService<TObject> where TObject : class
    {
        public TObject getById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
