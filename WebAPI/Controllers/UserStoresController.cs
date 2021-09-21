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
    [Authorize("ManagmentUsers")]
    public class UserStoresController : Controller
    {
        private readonly IUserStoresSevice _UserStoresService;

        public UserStoresController(IUserStoresSevice userStoresService)
        {
            _UserStoresService = userStoresService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Returns users stores for management user Roles")]
        public IActionResult GetAllWithFilters(int?  userId = null, int? storeId = null)
        {
            return Ok(new Response<IEnumerable<UserStoresDto>>(_UserStoresService.GetAllWithFilters(userId,storeId)));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adds User access to store for management user Roles")]
        public IActionResult Create(UserStoresCreateDto userStore)
        {
            var createdUserStore = _UserStoresService.Create(userStore);
            return Created($"api/userStores?userId={createdUserStore.UserId}&storeId={createdUserStore.StoreId}", createdUserStore);

        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Remove User access to store for management user Roles")]
        public IActionResult Delete(int userId, int storeId)
        {
            _UserStoresService.Delete(userId, storeId);
            return NoContent();
        }
    }
}
