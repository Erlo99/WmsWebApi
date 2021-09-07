using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICargosRepository
    {
        IEnumerable<Cargos> GetWithFilters(ref Pagination pagination, int? barcode = null, string Sku = null, string name = null);
        void Update(Cargos store);
        Cargos Create(Cargos store);
        void Delete(int barcode);
    }
}
