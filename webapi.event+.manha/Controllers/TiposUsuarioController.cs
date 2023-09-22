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
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepositoty();
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastro TipoUsuario
        /// </summary>
        /// <param name="tiposUsuario">objeto que será cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TiposUsuario tiposUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(tiposUsuario);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de deletar TipoUsuario por seu ID
        /// </summary>
        /// <param name="id">ID do objeto que será deletado </param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de buscar por ID
        /// </summary>
        /// <param name="id">ID do TipoUsuario que será buscado</param>
        /// <returns>objeto encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_tiposUsuarioRepository.BuscarPorId(id));

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de listar todos TipoUsuario
        /// </summary>
        /// <returns>Lista com todos objetos TipoUsuario</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               return Ok(_tiposUsuarioRepository.Listar());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de atualizar com o parâmetro ID
        /// </summary>
        /// <param name="id">ID do objeto TipoUsuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto TipoUsuario atualizado</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id, TiposUsuario tipoUsuarioAtualizado)
        {
            try
            {
                _tiposUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

                return NoContent();
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }

    
}
