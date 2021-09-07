using Application.DTO.Users;
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
    public class UserStoresController : Controller
    {
        private readonly IUserStoresSevice _UserStoresService;

        public UserStoresController(IUserStoresSevice userStoresService)
        {
            _UserStoresService = userStoresService;
        }

        [HttpGet]
        public IActionResult GetAllWithFilters(int?  userId = null, int? storeId = null)
        {
            return Ok(new Response<IEnumerable<UserStoresDto>>(_UserStoresService.GetAllWithFilters(userId,storeId)));
        }

        [HttpPost]
        public IActionResult Create(UserStoresCreateDto userStore)
        {
            var createdUserStore = _UserStoresService.Create(userStore);
            return Created($"api/userStores?userId={createdUserStore.UserId}&storeId={createdUserStore.StoreId}", createdUserStore);

        }

        [HttpDelete]
        public IActionResult Delete(int userId, int storeId)
        {
            _UserStoresService.Delete(userId, storeId);
            return NoContent();
        }
    }
}
