﻿using Application.DTO;
using Application.Helpers;
using Application.interfaces;
using Application.Middleware;
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
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargosService;

        public CargoController(ICargoService cargosService)
        {
            _cargosService = cargosService;
        }

        [HttpGet]
        [Authorize(Roles = "Accountant, Admin, SuperAdmin, Manager")]
        [SwaggerOperation(Summary = "Return All Cargoes | Roles with access: Accountant, Admin, SuperAdmin, Manager")]
        public IActionResult GetAllWithFilters([FromQuery] PaginationDto pagination = null, int? barcode = null, string sku = null, string name = null)
        {
            var result = _cargosService.GetAllWithFilters(barcode, sku, name);
            return Ok(PaginationHandler.Page(result, pagination));
        }

        [HttpDelete, Authorize("AdminUsers")]
        [SwaggerOperation(Summary = "Delete Cargo | Roles with access: Admin, SuperAdmin")]
        public IActionResult Delete(int barcode)
        {
            _cargosService.Delete(barcode);
            return NoContent();
        }
        [HttpPost, Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Add Cargo | Roles with access: Admin, SuperAdmin, Manager")]
        public IActionResult Create(CargoDto cargos)
        {
            _cargosService.Create(cargos);
            return Created($"/api/Cargos?barcode={cargos.Barcode}", cargos);
        }
        [HttpPut, Authorize("ManagmentUsers")]
        [SwaggerOperation(Summary = "Update Cargo | Roles with access: Admin, SuperAdmin, Manager")]
        public IActionResult Update(CargoDto cargos)
        {
            _cargosService.Update(cargos);
            return NoContent();
        }
    }
}
