using Bibliotech.Domain.Entites;
using Bibliotech.Service.Services;
using Bibliotech.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bibliotech.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/autores")]
    [ApiController]
    public class AutoresController : Controller
    {
        private BaseService<Autor> service = new BaseService<Autor>();

        [HttpPost]
        public IActionResult Inserir([FromBody] Autor item)
        {
            try
            {
                service.Inserir<AutorValidator>(item);

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
        public IActionResult Atualizar([FromBody] Autor item)
        {
            try
            {
                service.Atualizar<AutorValidator>(item);

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