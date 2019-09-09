using Bibliotech.Domain.Entites;
using Bibliotech.Service.Services;
using Bibliotech.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bibliotech.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/livros")]
    [ApiController]
    public class LivrosController : Controller
    {
        private LivroService service = new LivroService();

        [HttpPost]
        public IActionResult Inserir([FromBody] Livro item)
        {
            try
            {
                service.Inserir<LivroValidator>(item);

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
        public IActionResult Atualizar([FromBody] Livro item)
        {
            try
            {
                service.Atualizar<LivroValidator>(item);

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

        [Route("busca-filtrada")]
        [HttpGet]
        public IActionResult Buscar(string termo)
        {
            try
            {
                return new ObjectResult(service.Buscar(termo));
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