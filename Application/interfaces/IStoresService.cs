using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface ICargosService
    {
        public (IEnumerable<CargosDto>, PagedDto) GetAllWithFilters(ref PaginationDto pagination, int? barcode = null, string Sku = null, string name = null);
        public void Update(CargosDto store);
        public CargosDto Create(CargosDto store);
        public void Delete(int barcode);
    }
}
