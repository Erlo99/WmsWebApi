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

        public IEnumerable<CargoDto> GetAllWithFilters(int? barcode = null, string sku = null, string name = null)
        {
            var cargos = _cargosRepository.GetWithFilters(barcode, sku, name);
            return _mapper.Map<IEnumerable<CargoDto>>(cargos);
        }

        public void Update(CargoDto cargoData)
        {
            var cargoToUpdate = _cargosRepository.GetByBarcode(cargoData.Barcode);
            var cargo = _mapper.Map(cargoData, cargoToUpdate);
            _cargosRepository.Update(cargo);
        }
    }
}
