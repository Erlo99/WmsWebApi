using Application.DTO;
using Application.interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StoreService : IStoreService
    {

        private readonly IStoreRepository _storesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository storesRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _storesRepository = storesRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public (IEnumerable<StoreDTO>, PagedDto) GetAllWithFilters(ref PaginationDto paginationData, bool? isActive = null, bool? isDefault = null)
        {

            Pagination pagination = _mapper.Map<Pagination>(paginationData);
            var stores = _storesRepository.GetWithFilters(ref pagination, isActive, isDefault);

            var paged = _mapper.Map<PagedDto>(pagination);
            return (_mapper.Map<IEnumerable<StoreDTO>>(stores), paged);

        }

        public StoreDTO GetById(int id)
        {
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

    }
}
