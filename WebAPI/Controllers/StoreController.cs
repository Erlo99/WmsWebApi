
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
        public IActionResult GetAllWithFilters([FromQuery] PaginationDto pagination = null, bool? isActive = null, bool? isDefault = null, string name = null)
        {
            var stores = _storesService.GetAllWithFilters(ref pagination, isActive, isDefault, name);
            return Ok(new PagedResponse<StoreDTO>(stores));
        }
        [HttpPost, Authorize("AdminUsers")]
        public IActionResult PostStore(StoreCreateDto store)
        {
            var createdStore = _storesService.Create(store);
            return Created($"api/stores/{createdStore.Id}", createdStore);
        }
        [HttpPut, Authorize("AdminUsers")]
        public IActionResult PutStore(int id, StoreCreateDto store)
        {
            _storesService.Update(id, store);
            return NoContent();
        }


    }
}
