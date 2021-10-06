﻿using Application.Helpers;
using AutoMapper;
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
    public class RoleController : ControllerBase
    {

        [HttpGet]
        [SwaggerOperation(Summary = "Return all user roles | For authorized users")]
        public IActionResult GetAll()
        {
            var dict = new Dictionary<int, string>();
            foreach (var name in Enum.GetNames(typeof(RoleEnum)))
            {
                dict.Add((int)Enum.Parse(typeof(RoleEnum), name), name);
            }
            return (Ok(new Response<Dictionary<int, string>>(dict)));
        }
    }
}
