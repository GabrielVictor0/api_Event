using System.ComponentModel.Design;
using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.ViewModels;

namespace webapi.event_.manha.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Evento eventoAtualizado)
        {
            Evento eventoBuscado = _eventContext.Evento.Find(id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;

                eventoBuscado.DataEvento = eventoAtualizado.DataEvento;

                eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento;

                eventoBuscado.Descricao = eventoAtualizado.Descricao;

                eventoBuscado.IdInstituicao = eventoAtualizado.IdInstituicao;
            }
            _eventContext.Evento.Update(eventoBuscado!);
            _eventContext.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            return _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;
        }

        public void Cadastrar(Evento novoEvento)
        {
            _eventContext.Evento.Add(novoEvento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Evento eventoBuscado = _eventContext.Evento.Find(id)!;

            _eventContext.Evento.Remove(eventoBuscado);

            _eventContext.SaveChanges();    
        }

        public List<Evento> ListaEvento()
        {
            return _eventContext.Evento.ToList();
        }
    }
}
