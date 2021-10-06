using Application.DTO;
using Application.Helpers;
using Application.interfaces;
using Application.Middleware;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationSizeController : ControllerBase
    {
        private readonly ILocationSizeService _locationSizesService;

        public LocationSizeController(ILocationSizeService locationSizesService)
        {
            _locationSizesService = locationSizesService;
        }

        // POST: LocationSizesController/Create
        [HttpPost, Authorize("AdminUsers")]
        [SwaggerOperation(Summary = "Create location size | Roles with access: Admin, SuperAdmin")]
        public IActionResult Create(CreateLocationSizeDto locationSize)
        {
            var locationSizeCreated = _locationSizesService.Create(locationSize);
            return Created($"api/locationSizes/{locationSizeCreated.Id}", locationSize);
        }

        [HttpGet, Route("{id}")]
        [SwaggerOperation(Summary = "Return location size | For authorized users")]
        public IActionResult GetById(int id)
        {
            var locationSize = _locationSizesService.GetById(id);
            return Ok(new Response<LocationSizeDto>(locationSize));
        }

        [HttpGet, Authorize("AdminUsers")]
        [SwaggerOperation(Summary = "Return all location sizes | Roles with access: Admin, SuperAdmin")]
        public IActionResult GetAllWithFilters([FromQuery] PaginationDto pagination = null,string category = null, string sizeName = null, int? quantity = null)
        {
            var locationSizes = _locationSizesService.GetWithFilters(category, sizeName, quantity);
            return Ok(PaginationHandler.Page(locationSizes, pagination));
        }

        [HttpDelete, Authorize("AdminUsers")]
        [SwaggerOperation(Summary = "Delete location size | Roles with access: Admin, SuperAdmin")]
        public IActionResult delete(int id)
        {
            _locationSizesService.Delete(id);
            return NoContent();
        }
        [HttpPut, Authorize("AdminUsers"), Route("{id}")]
        [SwaggerOperation(Summary = "Update location size | Roles with access: Admin, SuperAdmin")]
        public IActionResult Update(int id, CreateLocationSizeDto locationSize)
        {
            _locationSizesService.Update(id, locationSize);
            return NoContent();
        }


    }
}
