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
    public class ClienteController : ControllerBase
    {


        private readonly ClienteRepository clienteRepository;

        public ClienteController(DataBaseContext context)
        {
            clienteRepository = new ClienteRepository(context);
        }


        [HttpGet]
        public ActionResult<List<ClienteModel>> Get()
        {
            try
            {
                var lista = clienteRepository.Listar();

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
        public ActionResult<ClienteModel> Get([FromRoute] int id)
        {
            try
            {
                var ClienteModel = clienteRepository.Consultar(id);

                if (ClienteModel != null)
                {
                    return Ok(ClienteModel);
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


        [HttpPost]
        public ActionResult<ClienteModel> Post([FromBody] ClienteModel ClienteModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                clienteRepository.Inserir(ClienteModel);
                var location = new Uri(Request.GetEncodedUrl()  + ClienteModel.ClienteId);
                return Created(location, ClienteModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir Cliente. Detalhes: {error.Message}" });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<ClienteModel> Put([FromRoute] int id, [FromBody] ClienteModel ClienteModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ClienteModel.ClienteId != id)
            {
                return NotFound();
            }


            try
            {
                clienteRepository.Alterar(ClienteModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar Cliente. Detalhes: {error.Message}" });
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult<ClienteModel> Delete([FromRoute] int id)
        {
            try
            {
                var ClienteModel = clienteRepository.Consultar(id);

                if (ClienteModel != null)
                {
                    clienteRepository.Excluir(id);
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }



    }
}
