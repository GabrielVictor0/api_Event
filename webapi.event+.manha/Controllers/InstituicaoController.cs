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
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastro de Instituicao
        /// </summary>
        /// <param name="instituicaoNova">obejto(instituicao) que será cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Instituicao instituicaoNova)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicaoNova);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de Buscar objeto pelo ID
        /// </summary>
        /// <param name="id">ID do objeto(instituicao) que vai ser buscado</param>
        /// <returns>retorna objeto com o ID buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_instituicaoRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de ListaInstituicao
        /// </summary>
        /// <returns>retorna ListaInstituicao com todos objetos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_instituicaoRepository.ListarInstituicao());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de Deletar Instituicao pelo ID
        /// </summary>
        /// <param name="id">ID da instituicao que vai ser deletada</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _instituicaoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de atualizar instituicao pelo ID
        /// </summary>
        /// <param name="id">ID da instituicao atualizada</param>
        /// <param name="instituicaoAtualizada">instituicao atualizada</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id, Instituicao instituicaoAtualizada)
        {
            try
            {
                _instituicaoRepository.Atualizar(id, instituicaoAtualizada);

                return NoContent();
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
