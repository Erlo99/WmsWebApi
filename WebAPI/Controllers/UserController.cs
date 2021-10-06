﻿using Application.DTO;
using Application.DTO.Users;
using Application.Entities;
using Application.Helpers;
using Application.interfaces;
using Application.Middleware;
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
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _usersService;
        private readonly IAuthService _authService;
        public UserController(IUserService usersService, IAuthService authService)
        {
            _usersService = usersService;
            _authService = authService;
        }

        [HttpGet, Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Returns All users for management user Roles")]
        public IActionResult GetWithFilters([FromQuery] PaginationDto pagination = null, string username = null, RolesEnum? role = null)
        {
            var users = _usersService.GetAllWithFilters(username, role);
            return Ok(PaginationHandler.Page(users,pagination));
        }

        [HttpGet, Route("{id}"), Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Returns user data for management user Roles")]
        public IActionResult GetById(int id)
        {
            var user = _usersService.GetById(id);
            return Ok(new Response<UserDto>(user));
        }
        [HttpGet, Route("CurrentUser")]
        [SwaggerOperation(Summary = "Returns current user data")]
        public IActionResult GetCurrentUser()
        {
            var user = _usersService.GetCurrentUser();
            return Ok(new Response<UserDto>(user));
        }

        [HttpPost, Route("Authentication")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Returns user when credentials are correct")]
        public IActionResult Authenticate(UserAuthenticate userAuthenticate)
        {
            var user = _authService.Authenticate(userAuthenticate.UserName, userAuthenticate.Password);

            if (user == null)
                return BadRequest("Incorrect username or password");
            return NoContent();
        }

        [HttpPost, Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Adds new user for management user Roles")]
        public IActionResult PostUser(CreateUserDto userData)
        {
            var user = _usersService.CreateUser(userData);
            return Created($"api/users/{user.Id}", user);
        }

        [HttpPut, Route("{id}"), Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "update user data for management user Roles")]
        public IActionResult PutUser(int id, UpdateUserDto userData)
        {
            _usersService.UpdateUser(id, userData);
            return NoContent();
        }

        [HttpDelete, Route("{id}"), Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Deletes user data for administrative user Roles")]
        public IActionResult Deleteuser(int id)
        {
                _usersService.DeleteUser(id);
            return NoContent();
        }
    }
}
