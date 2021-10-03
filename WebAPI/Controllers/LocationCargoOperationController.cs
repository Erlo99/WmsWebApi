using Application.DTO;
using Application.Helpers;
using Application.interfaces;
using Application.Services;
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
    public class LocationCargoOperationController : ControllerBase
    {
        private readonly ILocationCargoOperationSevice _locationCargoOperationService;

        public LocationCargoOperationController(ILocationCargoOperationSevice locationCargoOperationService)
        {
            _locationCargoOperationService = locationCargoOperationService;
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
        public IActionResult GetAllLocationCargoOperationsWithFilters([FromQuery] PaginationDto pagination, [FromQuery] LocationCargoOperationDto operation = null)
        {
            var result = _locationCargoOperationService.GetAllWithFilters(ref pagination, operation);
            return Ok( new PagedResponse<LocationCargoOperationDto>(result));
            
        }



    }
}
