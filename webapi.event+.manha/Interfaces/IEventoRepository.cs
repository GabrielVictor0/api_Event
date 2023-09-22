using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento eventoNovo);

        void Deletar(Guid id);

        List<Evento> ListaEvento();

        Evento BuscarPorId(Guid id);

        void Atualizar(Guid id, Evento eventoAtualizado);
    }
}
