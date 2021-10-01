
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
    [Authorize("AdminUsers")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storesService;
        public StoreController(IStoreService storesService)
        {
            _storesService = storesService;
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetById(int id)
        {
            var store = _storesService.GetById(id);
            if (store == null)
                return BadRequest(ResponseMessage.BadRequestForId);
            return Ok(new Response<StoreDTO>(store));
        }

        [HttpGet]
        public IActionResult GetAllWithFiltersAdmin([FromQuery] PaginationDto pagination = null, bool? isActive = null, bool? isDefault = null)
        {
            var stores = _storesService.GetAllWithFilters(ref pagination, isActive, isDefault);
            return Ok(new PagedResponse<StoreDTO>(stores));
        }
        [HttpPost]
        public IActionResult PostStore(StoreCreateDto store)
        {
            var createdStore = _storesService.Create(store);
            return Created($"api/stores/{createdStore.Id}", createdStore);
        }
        [HttpPut]
        public IActionResult PutStore(int id, StoreCreateDto store)
        {
            _storesService.Update(id, store);
            return NoContent();
        }


    }
}
