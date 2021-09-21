using Application.DTO;
using Application.Helpers;
using Application.interfaces;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class LocationCargosController : ControllerBase
    {
        private readonly ILocationCargosService _locationCargosService;

        public LocationCargosController(ILocationCargosService locationCargosService)
        {
            _locationCargosService = locationCargosService;
        }

        [HttpGet]
        public IActionResult GetAllWithFilters(int? locationId = null, int? barcode = null)
        {
            return Ok(new Response<IEnumerable<LocationCargosDto>>(_locationCargosService.GetAllWithFilters(locationId, barcode)));
        }

        [HttpPut]
        [Authorize(Roles = "Worker,Admin,SuperAdmin,Manager")]
        public IActionResult Update(int locationId, int barcode, LocationCargosDto locationCargo)
        {
            _locationCargosService.Update(locationId, barcode, locationCargo);
            return NoContent();
        }
    }
}
