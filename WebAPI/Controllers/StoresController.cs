
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
    public class StoresController : ControllerBase
    {
        private readonly IStoresService _storesService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StoresController(IStoresService storesService, IHttpContextAccessor httpContextAccessor)
        {
            _storesService = storesService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetById(int id)
        {
            var store = _storesService.GetById(id);
            if (store == null)
                return BadRequest(ResponseMessage.BadRequestForId);
            return Ok(new Response<StoresDTO>(store));
        }
        [HttpGet, Authorize("AdminUsers")]
        public IActionResult GetAllWithFilters([FromQuery] PaginationDto pagination = null, bool? isActive = null, bool? isDefault = null)
        {
            var stores = _storesService.GetAllWithFilters(ref pagination, isActive, isDefault);
            return Ok(new PagedResponse<StoresDTO>(stores));
        }
        [HttpPost, Authorize("AdminUsers")]
        public IActionResult PostStore(StoreCreateDto store)
        {
            var createdStore = _storesService.Create(store);
            return Created($"api/stores/{createdStore.Id}", new Response<StoresDTO>(createdStore));
        }
        [HttpPut, Authorize("AdminUsers")]
        public IActionResult PutStore(int id, StoreCreateDto store)
        {
            _storesService.Update(id, store);
            return NoContent();
        }


    }
}
