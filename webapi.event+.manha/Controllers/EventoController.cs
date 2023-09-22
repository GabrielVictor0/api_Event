using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;
using webapi.event_.manha.ViewModels;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        private IEventoRepository _eventoRepository;

        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastro Evento
        /// </summary>
        /// <param name="eventoNovo">Novo evento cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Evento eventoNovo)
        {
            try
            {
                _eventoRepository.Cadastrar(eventoNovo);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de ListaEvento 
        /// </summary>
        /// <returns>retorna lista de evento com todos objetos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.ListaEvento());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de buscar evento pelo ID
        /// </summary>
        /// <param name="id">ID do evento buscado</param>
        /// <returns>evento que possui ID buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_eventoRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de deletar evento pelo ID
        /// </summary>
        /// <param name="id">ID do evento que será deletado</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de atualizar evento pelo ID
        /// </summary>
        /// <param name="evento">objeto(evento0 atualizado</param>
        /// <param name="id">ID do evento que será atualizado</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Evento evento, Guid id)
        {
            try
            {
                _eventoRepository.Atualizar(id, evento);

                return NoContent();
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
