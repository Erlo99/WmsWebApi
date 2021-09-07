using Application.DTO.Users;
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
    public class UserStoresService : IUserStoresSevice
    {
        private readonly IUserStoresRepository _userStoresRepository;
        private readonly IMapper _mapper;

        public UserStoresService(IUserStoresRepository userStoresRepository, IMapper mapper)
        {
            _userStoresRepository = userStoresRepository;
            _mapper = mapper;
        }

        public UserStoresDto Create(UserStoresCreateDto userStoreData)
        {
            var userStore = _mapper.Map<UserStores>(userStoreData);
            var createdUserStore = _userStoresRepository.Create(userStore);
            return _mapper.Map<UserStoresDto>(createdUserStore);
        }

        public void Delete(int userId, int storeId)
        {
            _userStoresRepository.Delete(userId, storeId);
        }

        public IEnumerable<UserStoresDto> GetAllWithFilters(int? userId = null, int? storeId = null)
        {
            var userStores = _userStoresRepository.GetAllWithFilters(userId, storeId);

            return _mapper.Map<IEnumerable<UserStoresDto>>(userStores);
        }
    }
}
