using Application.DTO;
using Application.Helpers;
using Application.interfaces;
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
        private readonly IUserOperationsService _userOperationsService;

        public OperationsController(IUserOperationsService userOperationsService)
        {
            _userOperationsService = userOperationsService;
        }

        [HttpGet]
        public IActionResult GetAllOperations()
        {
            var dict = new Dictionary<int, string>();
            foreach (var name in Enum.GetNames(typeof(OperationsEnum)))
            {
                dict.Add((int)Enum.Parse(typeof(OperationsEnum), name), name);
            }
            return (Ok(new Response<Dictionary<int, string>>(dict)));
        }

        [HttpGet, Route("UserOperations")]
        public IActionResult GetAllUserOperationsWithFilters([FromQuery] PaginationDto pagination, string userName = null, string LocationName = null, DateTime? operationDate = null, string storeName = null, string operationName = null)
        {
            return Ok( new PagedResponse<UserOperationsDto>(_userOperationsService.GetAllWithFilters(ref pagination, userName, LocationName, operationDate, storeName, operationName)));
            
        }



    }
}
