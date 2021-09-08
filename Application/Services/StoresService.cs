using Application.DTO;
using Application.interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StoresService : IStoresService
    {

        private readonly IStoresRepository _storesRepository;
        private readonly IMapper _mapper;

        public StoresService(IStoresRepository storesRepository, IMapper mapper)
        {
            _storesRepository = storesRepository;
            _mapper = mapper;
        }

        public (IEnumerable<StoresDTO>, PagedDto) GetAllWithFilters(ref PaginationDto paginationData, bool? isActive = null, bool? isDefault = null)
        {

            Pagination pagination = _mapper.Map<Pagination>(paginationData);
            var stores = _storesRepository.GetWithFilters(ref pagination, isActive, isDefault);

            var paged = _mapper.Map<PagedDto>(pagination);
            return (_mapper.Map<IEnumerable<StoresDTO>>(stores), paged);

        }

        public StoresDTO GetById(int id)
        {
            var store = _storesRepository.GetById(id);
            return _mapper.Map<StoresDTO>(store);
        }

        public void Update(int id, StoreCreateDto storeData)
        {
            var store = _storesRepository.GetById(id);
            var storeUpdated = _mapper.Map(storeData, store);
            _storesRepository.Update(storeUpdated);
        }

        public StoresDTO Create(StoreCreateDto storeData)
        {
            var storeToCreate = _mapper.Map<Stores>(storeData);
            var store = _storesRepository.Create(storeToCreate);
            return _mapper.Map<StoresDTO>(store);
        }

        public void Delete(int id)
        {
            var store = _storesRepository.GetById(id);
        }

    }
}
