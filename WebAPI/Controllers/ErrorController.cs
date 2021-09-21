using Application.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;
        private string Message;
        private const string DefaultMessage = "Provided data is incorrect";
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }
        [Route("/error-dev")]
        [HttpGet]
        public IActionResult ErrorDev() 
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            Message = exception.Error.Message;
            if (exception.Error is BadRequestException)
                return Problem(title: (String.IsNullOrEmpty(Message) ? DefaultMessage : Message), statusCode: 400, detail: exception.Error.StackTrace);
            _logger.LogError($"Error occured on path: {exception.Path} with Exception: ", exception.Error);
            return Problem(title: exception.Error.Message, detail: exception.Error.StackTrace);
        }

        [Route("/error")]
        [HttpGet]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if(exception.Error is BadRequestException)
                return BadRequest(exception.Error.Message);
            _logger.LogError($"Error occured on path: {exception.Path} with Exception: ", exception.Error);
            return Problem(title: "Error occured while fulfilling request");
        }

    }
}
