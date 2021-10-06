using Application.DTO;
using Application.Helpers;
using Application.interfaces;
using Application.Middleware;
using Application.Services;
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
    [Authorize(Roles = "Accountant, Admin, SuperAdmin, Manager")]
    public class LocationCargoOperationController : ControllerBase
    {
        private readonly ILocationCargoOperationSevice _locationCargoOperationService;

        public LocationCargoOperationController(ILocationCargoOperationSevice locationCargoOperationService)
        {
            _locationCargoOperationService = locationCargoOperationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Return all operations on cargoes | Roles with access: Accountant, Admin, SuperAdmin, Manager")]
        public IActionResult GetAllOperations()
        {
            var dict = new Dictionary<int, string>();
            foreach (var name in Enum.GetNames(typeof(OperationEnum)))
            {
                dict.Add((int)Enum.Parse(typeof(OperationEnum), name), name);
            }
            return Ok(new Response<Dictionary<int, string>>(dict));
        }

        [HttpGet, Route("UserOperations")]
        [SwaggerOperation(Summary = "Return all user operations of cargoes on locations | Roles with access: Accountant, Admin, SuperAdmin, Manager")]
        public IActionResult GetAllLocationCargoOperationsWithFilters([FromQuery] PaginationDto pagination, [FromQuery] LocationCargoOperationDto operation = null)
        {
            var result = _locationCargoOperationService.GetAllWithFilters(operation);
            return Ok(PaginationHandler.Page(result, pagination));
        }



    }
}
