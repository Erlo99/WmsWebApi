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
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UserStoresService(IUserStoresRepository userStoresRepository, IUsersService usersService, IMapper mapper)
        {
            _userStoresRepository = userStoresRepository;
            _mapper = mapper;
            _usersService = usersService;
        }

        public UserStoresDto Create(UserStoresCreateDto userStoreData)
        {
            _usersService.GetById(userStoreData.UserId);
            var userStore = _mapper.Map<UserStores>(userStoreData);
            var createdUserStore = _userStoresRepository.Create(userStore);
            return _mapper.Map<UserStoresDto>(createdUserStore);
        }

        public void Delete(int userId, int storeId)
        {
            _usersService.GetById(userId);
            _userStoresRepository.Delete(userId, storeId);
        }

        public IEnumerable<UserStoresDto> GetAllWithFilters(int? userId = null, int? storeId = null)
        {
            var userStores = _userStoresRepository.GetAllWithFilters(userId, storeId);

            return _mapper.Map<IEnumerable<UserStoresDto>>(userStores);
        }

        public void InsertDefaultStoresToUser(int userId)
        {
            _userStoresRepository.InsertDefaultStores(userId);
        }
    }
}
