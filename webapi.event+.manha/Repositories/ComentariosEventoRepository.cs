using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class ComentariosEventoRepository : IComentariosEventoRepository
    {
        private readonly EventContext _eventContext;

        public ComentariosEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public ComentariosEvento BuscarPorId(Guid id)
        {
            return _eventContext.ComentariosEventos.FirstOrDefault(c => c.IdComentarioEvento == id)!;
        }

        public void Cadastrar(ComentariosEvento comentarioEvento)
        {
            _eventContext.ComentariosEventos.Add(comentarioEvento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            ComentariosEvento comentarioBuscado = _eventContext.ComentariosEventos.Find(id)!;

            _eventContext.ComentariosEventos.Remove(comentarioBuscado);

            _eventContext.SaveChanges();
        }

        public List<ComentariosEvento> ListaComentario()
        {
            return _eventContext.ComentariosEventos.ToList();
        }
    }
}
