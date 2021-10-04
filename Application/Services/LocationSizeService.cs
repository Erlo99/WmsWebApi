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
    public class LocationSizeService : ILocationSizeService
    {
        private readonly ILocationSizeRepository _locationSizesRepository;
        private readonly IMapper _mapper;

        public LocationSizeService(ILocationSizeRepository locationSizesRepository, IMapper mapper)
        {
            _locationSizesRepository = locationSizesRepository;
            _mapper = mapper;
        }

        public LocationSizeDto Create(CreateLocationSizeDto locationSize)
        {
            var locationSizeToChange = _mapper.Map<LocationSize>(locationSize);
            var newLocationSize = _locationSizesRepository.Create(locationSizeToChange);
            return _mapper.Map<LocationSizeDto>(newLocationSize);
        }

        public void Delete(int id)
        {
            _locationSizesRepository.Delete(id);
        }

        public LocationSizeDto GetById(int id)
        {
            var locationSize = _locationSizesRepository.GetById(id);
            return _mapper.Map<LocationSizeDto>(locationSize);
        }

        public IEnumerable<LocationSizeDto> GetWithFilters(string category = null, string sizeName = null, int? quantity = null)
        {
            var locationSizes = _locationSizesRepository.GetWithFilters(category, sizeName, quantity);
            return _mapper.Map<IEnumerable<LocationSizeDto>>(locationSizes);
        }

        public void Update(int id, CreateLocationSizeDto locationSize)
        {
            var locationSizeToUpdate = _locationSizesRepository.GetById(id);
            var locationSizeUpdated = _mapper.Map(locationSize, locationSizeToUpdate);
            _locationSizesRepository.Update(locationSizeToUpdate);
        }
    }
}
