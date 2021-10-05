using Application.DTO;
using Application.Helpers;
using Application.interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Services
{
    public class StoreService : IStoreService
    {

        private readonly IStoreRepository _storesRepository;
        private readonly IUserStoreRepository _userStoreRepository;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository storesRepository, IMapper mapper, IUserStoreRepository userStoreRepository)
        {
            _storesRepository = storesRepository;
            _mapper = mapper;
            _userStoreRepository = userStoreRepository;
        }

        public (IEnumerable<StoreDTO>, PagedDto) GetAllWithFilters(ref PaginationDto paginationData, bool? isActive = null, bool? isDefault = null, string name = null)
        {

            Pagination pagination = _mapper.Map<Pagination>(paginationData);
            var stores = _storesRepository.GetWithFilters(ref pagination, isActive, isDefault);

            if (!HttpContext.IsCurrentUserAdmin())
                foreach (int storeId in stores.ToList().Select(x => x.Id).Distinct())
                    if (_userStoreRepository.GetByKey(HttpContext.GetUserId(), storeId) == null)
                        stores = stores.Where( x => x.Id != storeId);

            var paged = _mapper.Map<PagedDto>(pagination);
            return (_mapper.Map<IEnumerable<StoreDTO>>(stores), paged);

        }

        public StoreDTO GetById(int id)
        {
            ValidateStoreAccess(id);
            var store = _storesRepository.GetById(id);
            return _mapper.Map<StoreDTO>(store);
        }

        public void Update(int id, StoreCreateDto storeData)
        {
            var store = _storesRepository.GetById(id);
            var storeUpdated = _mapper.Map(storeData, store);
            _storesRepository.Update(storeUpdated);
        }

        public StoreDTO Create(StoreCreateDto storeData)
        {
            var storeToCreate = _mapper.Map<Store>(storeData);
            var store = _storesRepository.Create(storeToCreate);
            return _mapper.Map<StoreDTO>(store);
        }

        public void Delete(int id)
        {
            _storesRepository.GetById(id);
        }

        public void ValidateStoreAccess(int id)
        {
            if (!HttpContext.IsCurrentUserAdmin())
                if (_userStoreRepository.GetByKey(HttpContext.GetUserId(), id) == null)
                    throw new BadRequestException(ResponseMessage.BadRequestForId);
        }
    }
}
