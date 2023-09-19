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

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
               Usuario usuario = _usarioRepositoy.BuscarPorId(id);

                return Ok(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
