using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        public IHelloWorld helloWorldService;
        private readonly ILogger<HelloWorldController>_logger;

        public HelloWorldController(ILogger<HelloWorldController> logger ,IHelloWorld ihelloWorld)
        {
            helloWorldService=ihelloWorld;
            _logger=logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Se llama a helloworld");
            return Ok(helloWorldService.Saludo());
        }
    }
}