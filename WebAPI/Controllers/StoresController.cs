
using Application.DTO;
using Application.Helpers;
using Application.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StoresController : ControllerBase
    {
        private readonly IStoresService _storesService;

        public StoresController(IStoresService storesService)
        {
            _storesService = storesService;
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetById(int id)
        {
            var store = _storesService.GetById(id);
            if (store == null)
                return BadRequest(ResponseMessage.BadRequestForId);
            return Ok(new Response<StoresDTO>(store));
        }
        [HttpGet]
        public IActionResult GetAllWithFilters([FromQuery] PaginationDto pagination = null, bool? isActive = null, bool? isDefault = null)
        {
            var stores = _storesService.GetAllWithFilters(ref pagination, isActive, isDefault);
            return Ok(new PagedResponse<StoresDTO>(stores));
        }
        [HttpPost]
        public IActionResult PostStore(StoreCreateDto store)
        {
            var createdStore = _storesService.Create(store);
            return Created($"api/stores/{createdStore.Id}", new Response<StoresDTO>(createdStore));
        }
        [HttpPut]
        public IActionResult PutStore(int id, StoreCreateDto store)
        {
            _storesService.Update(id, store);
            return NoContent();
        }


    }
}
