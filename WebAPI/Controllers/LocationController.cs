using Application.DTO;
using Application.DTO.Locations;
using Application.Helpers;
using Application.interfaces;
using Application.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        // POST: LocationSizesController/Create
        [HttpPost, Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Add location | Roles with access: Admin, SuperAdmin, Manager")]
        public IActionResult Create(LocationDto location)
        {
            var locationCreated = _locationService.Create(location);
            return Created($"api/locationSizes/{locationCreated.Id}", locationCreated);
        }

        [HttpGet, Route("{id}"), Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Return location | Roles with access: Admin, SuperAdmin, Manager")]
        public IActionResult GetById(int id)
        {
            var location = _locationService.GetById(id);
            return Ok(new Response<CreateLocationDto>(location));
        }

        [HttpGet, Authorize("AdminUsers")]
        [SwaggerOperation(Summary = "Add location | Roles with access: Admin, SuperAdmin")]
        public IActionResult GetAllWithFiltersAdmin([FromQuery] PaginationDto pagination = null, int? storeId = null, string column = null, int? row = null)
        {
            var location = _locationService.GetWithFilters(storeId, column,row);
            return Ok(PaginationHandler.Page(location, pagination));
        }

        [HttpGet, Route("store/{storeId}")]
        [SwaggerOperation(Summary = "Return location | For logged users")]
        public IActionResult GetAllWithFilters(int storeId, [FromQuery] PaginationDto pagination = null, string column = null, int? row = null)
        {
            var location = _locationService.GetWithFilters(storeId, column, row);
            return Ok(PaginationHandler.Page(location, pagination));
        }

        [HttpDelete, Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Delete location | Roles with access: Admin, SuperAdmin, Manager")]
        public IActionResult delete(int locationId)
        {
            _locationService.Delete(locationId);
            return NoContent();
        }

        [HttpPut, Route("{locationId}"), Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Update location | Roles with access: Admin, SuperAdmin, Manager")]
        public IActionResult Update(int locationId, LocationDto location)
        {
            _locationService.Update(locationId,location);
            return NoContent();
        }
    }
}
