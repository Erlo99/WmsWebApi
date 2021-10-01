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
    public class LocationCargoController : ControllerBase
    {
        private readonly ILocationCargoService _locationCargosService;

        public LocationCargoController(ILocationCargoService locationCargosService)
        {
            _locationCargosService = locationCargosService;
        }

        [HttpGet]
        public IActionResult GetAllWithFilters(int? locationId = null, int? barcode = null)
        {
            return Ok(new Response<IEnumerable<LocationCargoDto>>(_locationCargosService.GetAllWithFilters(locationId, barcode)));
        }

        [HttpPut]
        [Authorize(Roles = "Worker,Admin,SuperAdmin,Manager")]
        public IActionResult Update(LocationCargoDto locationCargo)
        {
            _locationCargosService.Update(locationCargo);
            return NoContent();
        }
    }
}
