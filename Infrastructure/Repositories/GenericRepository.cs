using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<TObject> : IGenericRepository<TObject> where TObject : class
    {
        private readonly WmsContext _context;

        public TObject GetById(Object id)
        {
            return _context.Set<TObject>().Find(id);
        }
    }
}
