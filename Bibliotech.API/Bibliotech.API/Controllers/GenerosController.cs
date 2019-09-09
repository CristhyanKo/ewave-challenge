using Bibliotech.Domain.Entites;
using Bibliotech.Service.Services;
using Bibliotech.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bibliotech.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/generos")]
    [ApiController]
    public class GenerosController : Controller
    {
        private BaseService<Genero> service = new BaseService<Genero>();

        [HttpPost]
        public IActionResult Inserir([FromBody] Genero item)
        {
            try
            {
                service.Inserir<GeneroValidator>(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Genero item)
        {
            try
            {
                service.Atualizar<GeneroValidator>(item);

                return new ObjectResult(item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult Remover(int id)
        {
            try
            {
                service.Remover(id);

                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            try
            {
                return new ObjectResult(service.Buscar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("busca-especifica")]
        [HttpGet]
        public IActionResult Buscar(int id)
        {
            try
            {
                return new ObjectResult(service.Buscar(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}