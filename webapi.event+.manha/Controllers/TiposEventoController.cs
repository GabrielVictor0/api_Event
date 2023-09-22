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
    public class TiposEventoController : ControllerBase
    {
        private ITiposEventoRepository _tiposEventoRepository;
        public TiposEventoController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastro TipoEvento
        /// </summary>
        /// <param name="novoEvento">obejto(Evento) que será cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TiposEvento novoEvento)
        {
            try
            {
                _tiposEventoRepository.Cadastrar(novoEvento);

                return StatusCode(201);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de Buscar TipoEvento pelo ID
        /// </summary>
        /// <param name="id">ID do TipoEvento que será buscado</param>
        /// <returns>Retorna o objeto com ID buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById( Guid id)
        {
            try
            {
                return Ok(_tiposEventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de ListarEventos
        /// </summary>
        /// <returns>Retorna todos TipoEvento</returns>
        [HttpGet]
        public IActionResult Get ()
        {
            try
            {
                return Ok(_tiposEventoRepository.ListarEvento());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de Deletar TipoEvento pelo ID
        /// </summary>
        /// <param name="id">ID do TipoEvento que será deletado</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposEventoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de Atualizar TipoEvento pelo ID
        /// </summary>
        /// <param name="id">ID do TipoEvento que será atualizado</param>
        /// <param name="novoEvento">TipoEvento atualizado</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id, TiposEvento novoEvento)
        {
            try
            {
                _tiposEventoRepository.Atualizar(novoEvento, id);

                return NoContent();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
