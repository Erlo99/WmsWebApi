
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
            return Ok(store);
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
            return Ok(_storesService.Create(store));
        }
        [HttpPut]
        public IActionResult PutStore(int id, StoreCreateDto store)
        {
            _storesService.Update(id, store);
            return NoContent();
        }


    }
}
