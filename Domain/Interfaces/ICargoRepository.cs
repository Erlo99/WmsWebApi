using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICargoRepository
    {
        Cargo GetByBarcode(int barcode);
        IEnumerable<Cargo> GetWithFilters( int? barcode = null, string Sku = null, string name = null);
        void Update(Cargo cargo);
        Cargo Create(Cargo cargo);
        void Delete(Cargo barcode);
    }
}
