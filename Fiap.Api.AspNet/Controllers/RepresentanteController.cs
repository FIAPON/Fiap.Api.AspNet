using Fiap.Api.AspNet.Models;
using Fiap.Api.AspNet.Repository;
using Fiap.Api.AspNet.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.AspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentanteController : ControllerBase
    {

        private readonly RepresentanteRepository representanteRepository;

        public RepresentanteController(DataBaseContext context)
        {
            representanteRepository = new RepresentanteRepository(context);
        }


        [HttpGet]
        public ActionResult<List<RepresentanteModel>> Get()
        {
            try
            {
                var lista = representanteRepository.Listar();

                if (lista != null)
                {
                    return Ok(lista);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<RepresentanteModel> Get([FromRoute] int id)
        {
            try
            {
                var representanteModel = representanteRepository.Consultar(id);

                if ( representanteModel != null  )
                {
                    return Ok(representanteModel);
                } else
                {
                    return NotFound();
                }
                
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        public ActionResult<RepresentanteModel> Post([FromBody] RepresentanteModel representanteModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                representanteRepository.Inserir(representanteModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + representanteModel.RepresentanteId);
                return Created(location, representanteModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir Representante. Detalhes: {error.Message}" });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<RepresentanteModel> Put([FromRoute] int id, [FromBody] RepresentanteModel representanteModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (representanteModel.RepresentanteId != id)
            {
                return NotFound();
            }


            try
            {
                representanteRepository.Alterar(representanteModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar Representante. Detalhes: {error.Message}" });
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult<RepresentanteModel> Delete([FromRoute] int id)
        {
            try { 
                var representanteModel = representanteRepository.Consultar(id);

                if (representanteModel != null)
                {
                    representanteRepository.Excluir(id);
                    // Retorno Sucesso.
                    // Efetuou a exclusão, porém sem necessidade de informar os dados.
                    return NoContent(); 
                } else
                {
                    return NotFound();
                }
            } catch (Exception e)
            {
                return BadRequest();
            }
        }



    }
}
