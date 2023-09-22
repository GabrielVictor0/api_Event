using Microsoft.EntityFrameworkCore;
using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Utils;

namespace webapi.event_.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = _eventContext.Usuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Nome = usuarioAtualizado.Nome;

                usuarioBuscado.Email = usuarioAtualizado.Email;

                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            _eventContext.Usuario.Update(usuarioBuscado!);

            _eventContext.SaveChanges();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    IdTipoUsuario = u.IdTipoUsuario,
                    TiposUsuario = new TiposUsuario
                    {
                        IdTipoUsuario = u.TiposUsuario!.IdTipoUsuario,
                        Titulo = u.TiposUsuario!.Titulo
                    }
                }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {   
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario
                .Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    IdTipoUsuario= u.IdTipoUsuario,
                    TiposUsuario = new TiposUsuario
                    {
                        IdTipoUsuario = u.TiposUsuario!.IdTipoUsuario,
                        Titulo = u.TiposUsuario!.Titulo
                    }
                }).FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Cadastrar(Usuario usuario)
        {
           
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _eventContext.Usuario.Add(usuario);

                _eventContext.SaveChanges();
           
        }

        public void Deletar(Guid id)
        {
           
               Usuario usuarioBuscado = _eventContext.Usuario.Find(id)!;

               _eventContext.Usuario.Remove(usuarioBuscado);

                _eventContext.SaveChanges();
            
          
        }
    }
}
