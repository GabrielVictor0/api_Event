using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class PresencasEventoRepository : IPresencasEventoRepository
    {
        private readonly EventContext _eventContext;

        public PresencasEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, PresencasEvento presenca)
        {
            PresencasEvento presencaBuscada = _eventContext.PresencasEvento.Find(id)!;

            if (presencaBuscada != null)
            {

                presencaBuscada.Situacao = presenca.Situacao;
            }

            _eventContext.PresencasEvento.Update(presencaBuscada!);

            _eventContext.SaveChanges();
        }

        public void Cadastrar(PresencasEvento presenca)
        {
            _eventContext.PresencasEvento.Add(presenca);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            PresencasEvento presencaBuscada = _eventContext.PresencasEvento.Find(id)!;

            _eventContext.PresencasEvento.Remove(presencaBuscada);

            _eventContext.SaveChanges();

        }

        public List<PresencasEvento> ListaPresenca()
        {
            return _eventContext.PresencasEvento.ToList();
        }

        public PresencasEvento ListarMinhaPresenca(Guid id)
        {
            return _eventContext.PresencasEvento.FirstOrDefault(p => p.IdPresencaEvento == id)!;
        }
    }
}
