using Application.DTO;
using Application.Helpers;
using Application.interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.Locations;

namespace Application.Services
{
    public class LocationService : ILocationService
    {

        private readonly ILocationRepository _locationRepository;
        private readonly IUserStoreRepository _userStoresRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository, IMapper mapper, IUserStoreRepository userStoresRepository)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
            _userStoresRepository = userStoresRepository;
        }

        public CreateLocationDto Create(LocationDto location)
        {
            if (!HttpContext.IsCurrentUserAdmin())
                if (_userStoresRepository.GetByKey(HttpContext.GetUserId(), location.StoreId) == null)
                    throw new BadRequestException(ResponseMessage.BadRequestForId);
                
            var newLocation = _mapper.Map<Location>(location);
            var createdLocation = _locationRepository.Create(newLocation);
            return _mapper.Map<CreateLocationDto>(createdLocation);
        }

        public void Delete(int id)
        {
            if (!HttpContext.IsCurrentUserAdmin())
                if (_userStoresRepository.GetByKey(HttpContext.GetUserId(), id) == null)
                    throw new BadRequestException(ResponseMessage.BadRequestForId);
            _locationRepository.Remove(id);
        }

        public LocationDto GetById(int id)
        {
            if (!HttpContext.IsCurrentUserAdmin())
                if (_userStoresRepository.GetByKey(HttpContext.GetUserId(), id) == null)
                    throw new BadRequestException(ResponseMessage.BadRequestForId);
            return _mapper.Map<LocationDto>(_locationRepository.GetById(id));
        }

        public (IEnumerable<LocationDto>, PagedDto) GetWithFilters(ref PaginationDto paginationData, int? storeId = null, string column = null, int? row = null)
        {
            
            Pagination pagination = _mapper.Map<Pagination>(paginationData);

            var locations = _locationRepository.GetAllWithFilters(ref pagination, storeId, column, row).ToList();
            var paged = _mapper.Map<PagedDto>(pagination);
            return (_mapper.Map<IEnumerable<LocationDto>>(locations.AsEnumerable()), paged);
        }

        public void Update(int locationId, LocationDto location)
        {
            if (!HttpContext.IsCurrentUserAdmin())
                if (_userStoresRepository.GetByKey(HttpContext.GetUserId(), location.StoreId) == null)
                    throw new BadRequestException(ResponseMessage.BadRequestForId);
            var existingLocation = _locationRepository.GetById(locationId);
            var locationToUpdate = _mapper.Map(location, existingLocation);
            _locationRepository.Update(locationToUpdate);
        }
    }
}
