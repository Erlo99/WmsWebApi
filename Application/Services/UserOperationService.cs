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
    public class UserOperationService : IUserOperationService
    {
        private readonly IUserOperationRepository _userOperationsRepository;
        private readonly IMapper _mapper;

        public UserOperationService(IUserOperationRepository userOperationsRepository, IMapper mapper)
        {
            _userOperationsRepository = userOperationsRepository;
            _mapper = mapper;
        }

        public (IEnumerable<UserOperationDto>, PagedDto) GetAllWithFilters(ref PaginationDto paginationData, string userName = null, string LocationName = null, DateTime? operationDate = null, string storeName = null, string operationName = null)
        {
            Pagination pagination = _mapper.Map<Pagination>(paginationData);

            var usersOperations = _userOperationsRepository.GetAllWithFilters(ref pagination, userName, LocationName, operationDate,storeName,operationName);

            var paged = _mapper.Map<PagedDto>(pagination);

            return (_mapper.Map<IEnumerable<UserOperationDto>>(usersOperations), paged);
        }
    }
}
