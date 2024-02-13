using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController:ControllerBase
    {
        public ITareaService tareaService;
        private readonly ILogger<TareaController> _logger;
        public TareaController(ITareaService service,ILogger<TareaController> logger)
        {
            _logger=logger;
            tareaService=service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tareaService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody]Tarea tarea)
        {
            tareaService.Post(tarea);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Post([FromBody]Tarea tarea,Guid id)
        {
            
            tareaService.Put(tarea,id);
            return Ok();
        }
          [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            
            tareaService.Delete(id);
            return Ok();
        }
    }
}