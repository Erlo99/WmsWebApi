
using Application.DTO;
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
        [SwaggerOperation(Summary = "Return store | For authorized users")]
        public IActionResult GetById(int id)
        {
            var store = _storesService.GetById(id);
            return Ok(new Response<StoreDTO>(store));
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Return all stores | For authorized users")]
        public IActionResult GetAllWithFilters([FromQuery] PaginationDto pagination = null, bool? isActive = null, bool? isDefault = null, string name = null)
        {
            var stores = _storesService.GetAllWithFilters(isActive, isDefault, name);
            return Ok(PaginationHandler.Page(stores, pagination));
        }
        [HttpPost, Authorize("AdminUsers")]
        [SwaggerOperation(Summary = "Add store | Roles with access: Admin, SuperAdmin")]
        public IActionResult CreateStore(StoreCreateDto store)
        {
            var createdStore = _storesService.Create(store);
            return Created($"api/stores/{createdStore.Id}", createdStore);
        }
        [HttpPut, Authorize("AdminUsers")]
        [SwaggerOperation(Summary = "Update store | Roles with access: Admin, SuperAdmin")]
        public IActionResult UpdateStore(int id, StoreCreateDto store)
        {
            _storesService.Update(id, store);
            return NoContent();
        }


    }
}
