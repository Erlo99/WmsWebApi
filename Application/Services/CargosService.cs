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
    public class CargosService : ICargosService
    {
        private readonly ICargosRepository _cargosRepository;
        private readonly IMapper _mapper;

        public CargosService(ICargosRepository cargosRepository, IMapper mapper)
        {
            _cargosRepository = cargosRepository;
            _mapper = mapper;
        }

        public CargosDto Create(CargosDto cargoData)
        {
            var cargo = _mapper.Map<Cargos>(cargoData);
            _cargosRepository.Create(cargo);
            return _mapper.Map<CargosDto>(cargo);
        }

        public void Delete(int barcode)
        {
            _cargosRepository.Delete(barcode);
        }

        public (IEnumerable<CargosDto>, PagedDto) GetAllWithFilters(ref PaginationDto paginationData, int? barcode = null, string sku = null, string name = null)
        {
            var pagination = _mapper.Map<Pagination>(paginationData);
            var cargos = _cargosRepository.GetWithFilters(ref pagination, barcode, sku, name);

            var paged = _mapper.Map<PagedDto>(pagination);
            return (_mapper.Map<IEnumerable<CargosDto>>(cargos), paged);
        }

        public void Update(CargosDto cargoData)
        {
            var cargoToUpdate = _cargosRepository.GetByBarcode(cargoData.Barcode);
            var cargo = _mapper.Map(cargoData, cargoToUpdate);
            _cargosRepository.Update(cargo);
        }
    }
}
