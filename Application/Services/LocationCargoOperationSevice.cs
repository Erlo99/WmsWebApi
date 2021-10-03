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

        public (IEnumerable<LocationCargoOperationDto>,PagedDto) GetAllWithFilters(ref PaginationDto pagination, LocationCargoOperationDto operation = null)
        {
            Pagination paginationData = _mapper.Map<Pagination>(pagination);

            var operationData = _mapper.Map<LocationCargoOperation>(operation);
            var result = _locationCargoOperationRepository.GetAllWithFilters(ref paginationData, operationData);
            var paged = _mapper.Map<PagedDto>(paginationData);
            return (_mapper.Map<IEnumerable<LocationCargoOperationDto>>(result),paged);
        }
    }
}
