﻿using Application.Helpers;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            var dict = new Dictionary<int, string>();
            foreach (var name in Enum.GetNames(typeof(OperationsEnum)))
            {
                dict.Add((int)Enum.Parse(typeof(OperationsEnum), name), name);
            }
            return (Ok(new Response<Dictionary<int,string>>(dict)));
        }
}
}
