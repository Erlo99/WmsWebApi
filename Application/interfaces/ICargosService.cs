using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface IStoresService
    {
        public (IEnumerable<StoresDTO>, PagedDto) GetAllWithFilters(ref PaginationDto pagination, bool? isActive = null, bool? isDefault = null);
        public StoresDTO GetById(int id);
        public void Update(int id, StoreCreateDto store);
        public StoresDTO Create(StoreCreateDto store);
        public void Delete(int id);
    }
}
