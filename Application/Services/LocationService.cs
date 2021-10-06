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
using Application.Middleware;

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
            ValidateDto(ref location);
            ValidateAccess(location.StoreId);

            var newLocation = _mapper.Map<Location>(location);
            var createdLocation = _locationRepository.Create(newLocation);
            return _mapper.Map<CreateLocationDto>(createdLocation);
        }

        public void Delete(int id)
        {
            ValidateAccess(id);
            _locationRepository.Remove(id);
        }

        public CreateLocationDto GetById(int id)
        {
            ValidateAccess(id);
            return _mapper.Map<CreateLocationDto>(_locationRepository.GetById(id));
        }

        public IEnumerable<CreateLocationDto> GetWithFilters(int? storeId = null, string column = null, int? row = null)
        {
            if(storeId != null)
                ValidateAccess(storeId.Value);
            var locations = _locationRepository.GetAllWithFilters(storeId, column.ToUpper(), row);
            return _mapper.Map<IEnumerable<CreateLocationDto>>(locations);
        }

        public void Update(int locationId, LocationDto location)
        {
            ValidateDto(ref location);
            ValidateAccess(location.StoreId);
            var existingLocation = _locationRepository.GetById(locationId);
            var locationToUpdate = _mapper.Map(location, existingLocation);
            _locationRepository.Update(locationToUpdate);
        }

        public void ValidateAccess(int id)
        {
            if (!HttpContext.IsCurrentUserAdmin())
                if (_userStoresRepository.GetByKey(HttpContext.GetUserId(), id) == null)
                    throw new BadRequestException(ResponseMessage.BadRequestForId);
        }

        public void ValidateDto(ref LocationDto location)
        {
            if (location.Column.Any(char.IsDigit))
                throw new BadRequestException("Column can't contain numbers");
            if (location.Column.Length > 2)
                throw new BadRequestException("Column max lenght is 2");
            location.Column = location.Column.ToUpper();
        }
    }
}
