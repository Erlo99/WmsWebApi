using Application.Entities;
using Application.interfaces;
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
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var users = _usersService.GetAllUsers();
            return Ok(users);
        }


        [HttpPost]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Returns user when credentials are correct")]
        public IActionResult Authenticate(UserAuthenticate userAuthenticate)
        {
            var user = _usersService.Authenticate(userAuthenticate.UserName, userAuthenticate.Password);

            if (user == null)
                return BadRequest("Incorrect username or password");
            return Ok(user);
        }


    }
}
