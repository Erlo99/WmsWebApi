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
    public class LocationCargoOperationSevice : ILocationCargoOperationSevice
    {
        private readonly IMapper _mapper;
        private readonly ILocationCargoOperationRepository _locationCargoOperationRepository;

        public LocationCargoOperationSevice(IMapper mapper, ILocationCargoOperationRepository locationCargoOperationRepository)
        {
            _mapper = mapper;
            _locationCargoOperationRepository = locationCargoOperationRepository;
        }

        public IEnumerable<LocationCargoOperationDto> GetAllWithFilters(LocationCargoOperationDto operation = null)
        {
            var operationData = _mapper.Map<LocationCargoOperation>(operation);
            var result = _locationCargoOperationRepository.GetAllWithFilters(operationData);
            return _mapper.Map<IEnumerable<LocationCargoOperationDto>>(result);
        }
    }
}
