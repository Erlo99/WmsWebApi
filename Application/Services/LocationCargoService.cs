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
using System.Web;

namespace Application.Services
{
    public class LocationCargoService : ILocationCargoService
    {

        private readonly ILocationCargoRepository _locationCargosRepository;
        private readonly IMapper _mapper;
        private readonly ILocationService _locationService;
        private readonly ILocationCargoOperationRepository _locationCargoOperationRepository;
        public LocationCargoService(ILocationCargoRepository locationCargosRepository, IMapper mapper, ILocationService locationService, ILocationCargoOperationRepository locationCargoOperationRepository)
        {
            _locationCargosRepository = locationCargosRepository;
            _mapper = mapper;
            _locationService = locationService;
            _locationCargoOperationRepository = locationCargoOperationRepository;
        }

        public CreateLocationCargoDto Create(LocationCargoDto locationCargo)
        {
            if (!HttpContext.IsCurrentUserAdmin())
                if (_locationService.GetById(locationCargo.LocationId) == null)
                    throw new BadRequestException(ResponseMessage.BadRequestForId);

            _locationService.GetById(locationCargo.LocationId);
            var locationCargoToCreate = _mapper.Map<LocationCargo>(locationCargo);
            var locationCargoAdded = _locationCargosRepository.Create(locationCargoToCreate);
            _locationCargoOperationRepository.AddOperation(new LocationCargoOperation() { 
                OperationId = OperationEnum.AddCargo,
                UserId = HttpContext.GetUserId(),
                Qty = locationCargo.Qty,
                Barcode = locationCargo.Barcode,
                LocationId = locationCargo.LocationId
            });
            return (_mapper.Map<CreateLocationCargoDto>(locationCargoAdded));

        }

        public IEnumerable<LocationCargoDto> GetAllWithFilters(int? locationId = null, int? barcode = null)
        {
            var locationCargos = _locationCargosRepository.GetAllWithFilters(locationId, barcode).ToList();
            foreach (var location in locationCargos.Select(x => x.LocationId).Distinct())
                try
                {
                    _locationService.GetById(location);
                }
                catch
                {
                    locationCargos.RemoveAll(x => x.LocationId == location);
                }

            return _mapper.Map<IEnumerable<LocationCargoDto>>(locationCargos); 
        }

        public void Update(LocationCargoDto locationCargo)
        {
            if (!HttpContext.IsCurrentUserAdmin())
                if (_locationService.GetById(locationCargo.LocationId) == null)
                    throw new BadRequestException(ResponseMessage.BadRequestForId);
            var existingLocationCargo = _locationCargosRepository.GetAllWithFilters(locationCargo.LocationId, locationCargo.Barcode).SingleOrDefault();

            

            if (existingLocationCargo == null)
            {
                if (locationCargo.Qty < 1) throw new BadRequestException("Quantity must be greater than 0");
                Create(locationCargo);
            }
            else
            {
                if (existingLocationCargo.Qty - locationCargo.Qty < 0)
                    throw new BadRequestException("Provided quanitity must be lower or equal to cargo quantity");
                var locationCargoToUpdate = _mapper.Map(locationCargo, existingLocationCargo);
                _locationCargosRepository.Update(locationCargoToUpdate);
                _locationCargoOperationRepository.AddOperation(new LocationCargoOperation()
                {
                    OperationId = OperationEnum.RemoveCargo,
                    Qty = locationCargo.Qty,
                    UserId = HttpContext.GetUserId(),
                    Barcode = locationCargo.Barcode,
                    LocationId = locationCargo.LocationId
                });
            }
            
        }

    }
}
