using Application.DTO;
using Application.Helpers;
using Application.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly ICargosService _cargosService;

        public CargosController(ICargosService cargosService)
        {
            _cargosService = cargosService;
        }

        [HttpGet]
        public IActionResult GetAllWithFilters([FromQuery] PaginationDto pagination = null, int? barcode = null, string sku = null, string name = null)
        {
            var result = _cargosService.GetAllWithFilters(ref pagination, barcode, sku, name);
            return Ok(new PagedResponse<CargosDto>(result));
        }

        [HttpDelete]
        public IActionResult Delete(int barcode)
        {
            _cargosService.Delete(barcode);
            return NoContent();
        }
        [HttpPost]
        public IActionResult Create(CargosDto cargos)
        {
            _cargosService.Create(cargos);
            return Created($"/api/Cargos?barcode={cargos.Barcode}", cargos);
        }
        [HttpPut]
        public IActionResult Update(CargosDto cargos)
        {
            _cargosService.Update(cargos);
            return NoContent();
        }
    }
}
