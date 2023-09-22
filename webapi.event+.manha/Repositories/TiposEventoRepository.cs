using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {
        private readonly EventContext _eventContext;

        public TiposEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(TiposEvento tipoEventoAtualizado, Guid id)
        {
            TiposEvento tipoEventoBuscado = _eventContext.TiposEvento.Find(id)!;

            if (tipoEventoBuscado != null)
            {
                tipoEventoBuscado.Titulo = tipoEventoAtualizado.Titulo;
            }

            _eventContext.TiposEvento.Update(tipoEventoBuscado!);

            _eventContext.SaveChanges();
        }

        public TiposEvento BuscarPorId(Guid id)
        {
            return _eventContext.TiposEvento.FirstOrDefault(u => u.IdTipoEvento == id)!;
        }

        public void Cadastrar(TiposEvento evento)
        {
            _eventContext.TiposEvento.Add(evento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposEvento tipoEventoBuscado = _eventContext.TiposEvento.Find(id)!;

            if (tipoEventoBuscado != null)
            {
                _eventContext.TiposEvento.Remove(tipoEventoBuscado);
            }

            _eventContext.SaveChanges();
        }

        public List<TiposEvento> ListarEvento()
        {
           return _eventContext.TiposEvento.ToList();
        }
    }
}
