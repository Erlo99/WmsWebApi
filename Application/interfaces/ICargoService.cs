using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface ICargoService
    {
        public (IEnumerable<CargoDto>, PagedDto) GetAllWithFilters(ref PaginationDto pagination, int? barcode = null, string Sku = null, string name = null);
        public void Update(CargoDto store);
        public CargoDto Create(CargoDto store);
        public void Delete(int barcode);
    }
}
