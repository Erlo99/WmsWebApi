using Application.DTO;
using Application.Helpers;
using Application.interfaces;
using Application.Services;
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
    public class LocationSizeController : ControllerBase
    {
        private readonly ILocationSizeService _locationSizesService;

        public LocationSizeController(ILocationSizeService locationSizesService)
        {
            _locationSizesService = locationSizesService;
        }

        // POST: LocationSizesController/Create
        [HttpPost, Authorize("ManagmentUsers")]
        public IActionResult Create(LocationSizeDto locationSize)
        {
            var locationSizeCreated = _locationSizesService.Create(locationSize);
            return Created($"api/locationSizes/{locationSizeCreated.Id}", locationSize);
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetById(int id)
        {
            var locationSize = _locationSizesService.GetById(id);
            return Ok(new Response<LocationSizeDto>(locationSize));
        }

        [HttpGet, Authorize("ManagmentUsers")]
        public IActionResult GetAllWithFilters(string category = null, string sizeName = null, int? quantity = null)
        {
            var locationSizes = _locationSizesService.GetWithFilters(category, sizeName, quantity);
            return Ok(new Response<IEnumerable<LocationSizeDto>>(locationSizes));
        }

        [HttpDelete, Authorize("ManagmentUsers")]
        public IActionResult delete(LocationSizeDto locationSize)
        {
            _locationSizesService.Create(locationSize);
            return NoContent();
        }
        [HttpPut, Authorize("ManagmentUsers")]
        public IActionResult Update(LocationSizeDto locationSize)
        {
            _locationSizesService.Update(locationSize);
            return NoContent();
        }


    }
}
