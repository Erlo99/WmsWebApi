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

namespace Application.Services
{
    public class LocationCargosService : ILocationCargosService
    {

        private readonly ILocationCargosRepository _locationCargosRepository;
        private readonly IMapper _mapper;

        public LocationCargosService(ILocationCargosRepository locationCargosRepository, IMapper mapper)
        {
            _locationCargosRepository = locationCargosRepository;
            _mapper = mapper;
        }

        public CreateLocationCargosDto Create(LocationCargosDto locationCargo)
        {
            var locationCargoToCreate = _mapper.Map<LocationCargos>(locationCargo);
            var locationCargoAdded = _locationCargosRepository.Create(locationCargoToCreate);
            return (_mapper.Map<CreateLocationCargosDto>(locationCargoAdded));

        }
        public LocationCargos Createv2(LocationCargosDto locationCargo)
        {
            var locationCargoToCreate = _mapper.Map<LocationCargos>(locationCargo);
            return _locationCargosRepository.Create(locationCargoToCreate);
        }

        public IEnumerable<LocationCargosDto> GetAllWithFilters(int? locationId = null, int? barcode = null)
        {
            var locationCargos = _locationCargosRepository.GetAllWithFilters(locationId, barcode);

            return _mapper.Map<IEnumerable<LocationCargosDto>>(locationCargos); 
        }

        public void Update(int locationId, int barcode, LocationCargosDto locationCargo)
        {
            var existingLocationCargo = _locationCargosRepository.GetAllWithFilters(locationId, barcode).SingleOrDefault();
            
            if (existingLocationCargo == null)
            {
                if (locationCargo.Qty < 1) throw new BadRequestException(ResponseMessage.BadRequestForId);
                Createv2(locationCargo);
                return;
            }
            if(existingLocationCargo.Qty - locationCargo.Qty < 0)
                throw new BadRequestException("Provided quanitity must be lower or equal to cargo quantity");
            var locationCargoToUpdate = _mapper.Map(locationCargo, existingLocationCargo);
            _locationCargosRepository.Update(locationCargoToUpdate);
        }

    }
}
