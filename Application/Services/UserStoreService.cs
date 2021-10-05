using Application.DTO.Users;
using Application.Helpers;
using Application.interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserStoreService : IUserStoreSevice
    {
        private readonly IUserStoreRepository _userStoresRepository;
        private readonly IUserService _usersService;
        private readonly IMapper _mapper;

        public UserStoreService(IUserStoreRepository userStoresRepository, IUserService usersService, IMapper mapper)
        {
            _userStoresRepository = userStoresRepository;
            _mapper = mapper;
            _usersService = usersService;
        }

        public UserStoreDto Create(CreateUserStoreDto userStoreData)
        {
            ValidateAccess(userStoreData.StoreId);
            _usersService.GetById(userStoreData.UserId);
            var userStore = _mapper.Map<UserStore>(userStoreData);
            var createdUserStore = _userStoresRepository.Create(userStore);
            return _mapper.Map<UserStoreDto>(createdUserStore);
        }

        public void Delete(int userId, int storeId)
        {
            ValidateAccess(storeId);
            _usersService.GetById(userId);
            _userStoresRepository.Delete(userId, storeId);
        }

        public IEnumerable<UserStoreDto> GetAllWithFilters(int? userId = null, int? storeId = null)
        {
            var userStores = _userStoresRepository.GetAllWithFilters(userId, storeId);
            if (!HttpContext.IsCurrentUserAdmin())
                foreach (int storeIdToVerify in userStores.ToList().Select(x => x.StoreId).Distinct())
                    if (_userStoresRepository.GetByKey(HttpContext.GetUserId(), storeIdToVerify) == null)
                        userStores = userStores.Where(x => x.StoreId != storeIdToVerify);

            return _mapper.Map<IEnumerable<UserStoreDto>>(userStores);
        }

        public void InsertDefaultStoresToUser(int userId)
        {
            _userStoresRepository.InsertDefaultStores(userId);
        }

        public void ValidateAccess(int storeId)
        {
            if (!HttpContext.IsCurrentUserAdmin())
                if (_userStoresRepository.GetByKey(HttpContext.GetUserId(), storeId) == null)
                    throw new BadRequestException(ResponseMessage.BadRequestForId);
        }
    }
}
