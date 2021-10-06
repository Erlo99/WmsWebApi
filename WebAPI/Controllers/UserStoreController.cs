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
        private readonly IUserStoreService _UserStoresService;

        public UserStoreController(IUserStoreService userStoresService)
        {
            _UserStoresService = userStoresService;
        }

        [HttpGet, Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Return  all user access to store | Roles with access: Admin, SuperAdmin, Manager")]
        public IActionResult GetAllWithFilters(int?  userId = null, int? storeId = null)
        {
            return Ok(new Response<IEnumerable<UserStoreDto>>(_UserStoresService.GetAllWithFilters(userId,storeId)));
        }

        [HttpGet, Route("{userId}")]
        [SwaggerOperation(Summary = "Return  all user access to store | For authorized users")]
        public IActionResult GetAllWithFiltersForUser(int? userId, int? storeId = null)
        {
            return Ok(new Response<IEnumerable<UserStoreDto>>(_UserStoresService.GetAllWithFilters(userId, storeId)));
        }

        [HttpPost, Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Add user access to store | Roles with access: Admin, SuperAdmin, Manager")]
        public IActionResult Create(CreateUserStoreDto userStore)
        {
            var createdUserStore = _UserStoresService.Create(userStore);
            return Created($"api/userStores?userId={createdUserStore.UserId}&storeId={createdUserStore.StoreId}", createdUserStore);

        }

        [HttpDelete, Route("{userId}/{storeId}"), Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Delete user access to store | Roles with access: Admin, SuperAdmin, Manager")]
        public IActionResult Delete(int userId, int storeId)
        {
            _UserStoresService.Delete(userId, storeId);
            return NoContent();
        }
    }
}
