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
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }
        [Route("/error-dev")]
        [HttpGet]
        public IActionResult ErrorDev() 
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _logger.LogError($"Error occured on path: {exception.Path} with Exception: ", exception.Error);
            return Problem(title: exception.Error.Message, detail: exception.Error.StackTrace);
        }

        [Route("/error")]
        [HttpGet]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _logger.LogError($"Error occured on path: {exception.Path} with Exception: ", exception.Error);
            return Problem(title: "Error occured while fulfilling request");
        }

    }
}
