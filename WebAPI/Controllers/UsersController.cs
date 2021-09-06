using Application.DTO;
using Application.DTO.Users;
using Application.Entities;
using Application.Helpers;
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
        public IActionResult GetWithFilters(string username = null, RolesEnum? role = null, [FromQuery] PaginationDto pagination = null)
        {
            pagination = pagination ?? new PaginationDto();
            var users = _usersService.GetAllWithFilters(ref pagination, username, role);
            return Ok(new PagedResponse<UsersDto>(users));
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _usersService.GetById(id);
            if (user == null)
                BadRequest(ResponseMessage.BadRequestForId);
            throw new Exception("123");
            return Ok();
        }

        [HttpPost, Route("Authentication")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Returns user when credentials are correct")]
        public IActionResult Authenticate(UserAuthenticate userAuthenticate)
        {
            var user = _usersService.Authenticate(userAuthenticate.UserName, userAuthenticate.Password);

            if (user == null)
                return BadRequest("Incorrect username or password");
            return Ok(new Response<UsersDto>(user));
        }

        [HttpPost]
        public IActionResult PostUser(CreateUsersDto userData)
        {
            var user = _usersService.CreateUser(userData);
            return Created($"api/users/{user.Id}", new Response<UsersDto>(user));
        }

        [HttpPatch, Route("{id}")]
        public IActionResult PatchUser(int id, UpdateUsersDTO userData)
        {
            _usersService.UpdateUser(id, userData);
            return NoContent();
        }
    }
}
