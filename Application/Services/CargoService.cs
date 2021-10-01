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
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargosRepository;
        private readonly IMapper _mapper;

        public CargoService(ICargoRepository cargosRepository, IMapper mapper)
        {
            _cargosRepository = cargosRepository;
            _mapper = mapper;
        }

        public CargoDto Create(CargoDto cargoData)
        {
            var cargo = _mapper.Map<Cargo>(cargoData);
            _cargosRepository.Create(cargo);
            return _mapper.Map<CargoDto>(cargo);
        }

        public void Delete(int barcode)
        {
            _cargosRepository.Delete(barcode);
        }

        public (IEnumerable<CargoDto>, PagedDto) GetAllWithFilters(ref PaginationDto paginationData, int? barcode = null, string sku = null, string name = null)
        {
            var pagination = _mapper.Map<Pagination>(paginationData);
            var cargos = _cargosRepository.GetWithFilters(ref pagination, barcode, sku, name);

            var paged = _mapper.Map<PagedDto>(pagination);
            return (_mapper.Map<IEnumerable<CargoDto>>(cargos), paged);
        }

        public void Update(CargoDto cargoData)
        {
            var cargoToUpdate = _cargosRepository.GetByBarcode(cargoData.Barcode);
            var cargo = _mapper.Map(cargoData, cargoToUpdate);
            _cargosRepository.Update(cargo);
        }
    }
}
