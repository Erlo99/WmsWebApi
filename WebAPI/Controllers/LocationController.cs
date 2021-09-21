using Application.DTO;
using Application.DTO.Location;
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
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        // POST: LocationSizesController/Create
        [HttpPost]
        [Authorize("ManagmentUsers")]
        public IActionResult Create(LocationDto location)
        {
            var locationCreated = _locationService.Create(location);
            return Created($"api/locationSizes/{locationCreated.Id}", new Response<CreateLocationsDto>(locationCreated));
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetById(int id)
        {
            var location = _locationService.GetById(id);
            return Ok(new Response<LocationDto>(location));
        }

        [HttpGet]
        public IActionResult GetAllWithFilters([FromQuery] PaginationDto pagination, int storeId, string column = null, int? row = null)
        {
            var location = _locationService.GetWithFilters(ref pagination, storeId, column,row);
            return Ok(new PagedResponse<LocationDto>(location));
        }

        [HttpDelete]
        [Authorize("ManagmentUsers")]
        public IActionResult delete(int locationId)
        {
            _locationService.Delete(locationId);
            return NoContent();
        }

        [HttpPut, Route("{locationId}")]
        [Authorize("ManagmentUsers")]
        public IActionResult Update(int locationId, LocationDto location)
        {
            _locationService.Update(locationId,location);
            return NoContent();
        }
    }
}
