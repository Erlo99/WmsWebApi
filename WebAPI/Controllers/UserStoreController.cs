using Application.DTO.Users;
using Application.Helpers;
using Application.interfaces;
using Microsoft.AspNetCore.Authorization;
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
    public class UserStoreController : Controller
    {
        private readonly IUserStoreSevice _UserStoresService;

        public UserStoreController(IUserStoreSevice userStoresService)
        {
            _UserStoresService = userStoresService;
        }

        [HttpGet, Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Returns users stores for management user Roles")]
        public IActionResult GetAllWithFilters(int?  userId = null, int? storeId = null)
        {
            return Ok(new Response<IEnumerable<UserStoreDto>>(_UserStoresService.GetAllWithFilters(userId,storeId)));
        }

        [HttpGet, Route("{userId}")]
        [SwaggerOperation(Summary = "Returns users stores for management user Roles")]
        public IActionResult GetAllWithFiltersForUser(int? userId, int? storeId = null)
        {
            return Ok(new Response<IEnumerable<UserStoreDto>>(_UserStoresService.GetAllWithFilters(userId, storeId)));
        }

        [HttpPost, Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Adds User access to store for management user Roles")]
        public IActionResult Create(CreateUserStoreDto userStore)
        {
            var createdUserStore = _UserStoresService.Create(userStore);
            return Created($"api/userStores?userId={createdUserStore.UserId}&storeId={createdUserStore.StoreId}", createdUserStore);

        }

        [HttpDelete, Route("{userId}/{storeId}"), Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Remove User access to store for management user Roles")]
        public IActionResult Delete(int userId, int storeId)
        {
            _UserStoresService.Delete(userId, storeId);
            return NoContent();
        }
    }
}
