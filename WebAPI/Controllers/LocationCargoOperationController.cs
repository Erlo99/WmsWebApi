using Application.DTO;
using Application.Helpers;
using Application.interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Accountant,Admin,SuperAdmin,Manager")]
    public class OperationController : ControllerBase
    {
        private readonly IUserOperationService _userOperationsService;

        public OperationController(IUserOperationService userOperationsService)
        {
            _userOperationsService = userOperationsService;
        }

        [HttpGet]
        public IActionResult GetAllOperations()
        {
            var dict = new Dictionary<int, string>();
            foreach (var name in Enum.GetNames(typeof(Operation)))
            {
                dict.Add((int)Enum.Parse(typeof(Operation), name), name);
            }
            return (Ok(new Response<Dictionary<int, string>>(dict)));
        }

        [HttpGet, Route("UserOperations")]
        public IActionResult GetAllUserOperationsWithFilters([FromQuery] PaginationDto pagination, string userName = null, string LocationName = null, DateTime? operationDate = null, string storeName = null, string operationName = null)
        {
            return Ok( new PagedResponse<UserOperationDto>(_userOperationsService.GetAllWithFilters(ref pagination, userName, LocationName, operationDate, storeName, operationName)));
            
        }



    }
}
