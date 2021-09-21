using Application.DTO;
using Application.DTO.Location;
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
    public class LocationService : ILocationService
    {

        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public CreateLocationsDto Create(LocationDto location)
        {
            var newLocation = _mapper.Map<Locations>(location);
            var createdLocation = _locationRepository.Create(newLocation);
            return _mapper.Map<CreateLocationsDto>(createdLocation);
        }

        public void Delete(int id)
        {
            _locationRepository.Remove(id);
        }

        public LocationDto GetById(int id)
        {
            return _mapper.Map<LocationDto>(_locationRepository.GetById(id));
        }

        public (IEnumerable<LocationDto>, PagedDto) GetWithFilters(ref PaginationDto paginationData, int storeId, string column = null, int? row = null)
        {
            Pagination pagination = _mapper.Map<Pagination>(paginationData);

            var locations = _locationRepository.GetAllWithFilters(ref pagination, storeId, column, row);

            var paged = _mapper.Map<PagedDto>(pagination);
            return (_mapper.Map<IEnumerable<LocationDto>>(locations), paged);
        }

        public void Update(int locationId, LocationDto location)
        {

            var existingLocation = _locationRepository.GetById(locationId);
            var locationToUpdate = _mapper.Map(location, existingLocation);
            _locationRepository.Update(locationToUpdate);
        }
    }
}
