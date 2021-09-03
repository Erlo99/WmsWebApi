using Application.DTO.Users;
using Application.Entities;
using Application.interfaces;
using Domain.Entities;
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
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult GetWithFilters(string username = null, RolesEnum? role = null)
        {
            var users = _usersService.GetAllWithFilters(null, username, role);
            return Ok(users);
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetById(int id)
        {
            var users = _usersService.GetAllWithFilters(id).ToList().First();
            return Ok(users);
        }

        [HttpPost, Route("Authentication")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Returns user when credentials are correct")]
        public IActionResult Authenticate(UserAuthenticate userAuthenticate)
        {
            var user = _usersService.Authenticate(userAuthenticate.UserName, userAuthenticate.Password);

            if (user == null)
                return BadRequest("Incorrect username or password");
            return Ok(user);
        }

        [HttpPost]
        public IActionResult PostUser(CreateUsersDto userData)
        {
            var user = _usersService.CreateUser(userData);
            return Created($"api/users/?id={user.Id}", user);
        }

        [HttpPatch, Route("{id}")]
        public IActionResult PatchUser(int id, UpdateUsersDTO userData)
        {
            _usersService.UpdateUser(id, userData);
            return NoContent();
        }
    }
}
