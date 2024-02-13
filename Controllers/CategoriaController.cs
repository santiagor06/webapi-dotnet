using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using api.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        public ICategoriaService categoriaService;
        private readonly ILogger<CategoriaController> _logger;
        public CategoriaController(ICategoriaService service,ILogger<CategoriaController> logger)
        {
            _logger=logger;
            categoriaService=service;
        }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoriaService.Get()) ;
    }
    [HttpPost]
    public IActionResult Post([FromBody]Categoria categoria)
    {
        categoriaService.Post(categoria);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put([FromBody]Categoria categoria,Guid id)
    {
        categoriaService.Put(categoria,id);
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoriaService.Delete(id);
        return Ok();
    }
    }
}