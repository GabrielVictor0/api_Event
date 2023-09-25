using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencasEventoController : ControllerBase
    {
        private IPresencasEventoRepository _presencasEventoRepository;

        public PresencasEventoController()
        {
            _presencasEventoRepository = new PresencasEventoRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastrar presencaEvento
        /// </summary>
        /// <param name="presencaEvento"> objeto(presencaEvento) que será cadastrado</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(PresencasEvento presencaEvento)
        {
            try
            {
                _presencasEventoRepository.Cadastrar(presencaEvento);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de deletar presencaEvento
        /// </summary>
        /// <param name="id">ID do objeto que será deletado</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencasEventoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que busca presencaEvento pelo ID
        /// </summary>
        /// <param name="id">ID do objeto que será buscado</param>
        /// <returns>retorna objeto que tem o ID buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_presencasEventoRepository.ListarMinhaPresenca(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de ListaPresenca
        /// </summary>
        /// <returns>Lista de presencas com todos objetos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencasEventoRepository.ListaPresenca());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de atualizar presencaEvento
        /// </summary>
        /// <param name="id">ID da presencaEvento que será buscada</param>
        /// <param name="presencaEvento">objeto(presencaEvento) atualizado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Guid id, PresencasEvento presencaEvento)
        {
            try
            {
                _presencasEventoRepository.Atualizar(id, presencaEvento);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
