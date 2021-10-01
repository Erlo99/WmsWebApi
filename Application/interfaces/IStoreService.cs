using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface IStoreService
    {
        public (IEnumerable<StoreDTO>, PagedDto) GetAllWithFilters(ref PaginationDto pagination, bool? isActive = null, bool? isDefault = null);
        public StoreDTO GetById(int id);
        public void Update(int id, StoreCreateDto store);
        public StoreDTO Create(StoreCreateDto store);
        public void Delete(int id);
    }
}
