using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usarioRepositoy;

        public UsuarioController()
        {
            _usarioRepositoy = new UsuarioRepository();
        }

        /// <summary>
        /// EndPint que aciona o método de cadastro de usuario
        /// </summary>
        /// <param name="usuario">objeto(usuario) que será cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usarioRepositoy.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de buscar objeto(usuario) pelo ID
        /// </summary>
        /// <param name="id">ID do objeto que será buscado</param>
        /// <returns>retorna o obejto buscado pelo ID</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
               Usuario usuario = _usarioRepositoy.BuscarPorId(id);

                return Ok(usuario);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de Busca com os parâmetros Email e Senha
        /// </summary>
        /// <param name="email">email do objeto que será buscado</param>
        /// <param name="senha">senha do objeto que será buscado</param>
        /// <returns>retorna o objeto(usuario) buscado pelo email e senha</returns>
        [HttpGet]
        public IActionResult Get(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _usarioRepositoy.BuscarPorEmailESenha(email, senha);

               return Ok(usuarioBuscado);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de Deletar objeto(usuario) pelo ID
        /// </summary>
        /// <param name="id">ID do objeto que será deletado</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _usarioRepositoy.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de atualizar objeto(usuario) pelo seu ID
        /// </summary>
        /// <param name="id">ID do objeto que será deletado</param>
        /// <param name="usuarioAtualizado">Informações atualidas do objeto</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id, Usuario usuarioAtualizado)
        {
            try
            {
                _usarioRepositoy.Atualizar(id, usuarioAtualizado);

                return NoContent();
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
