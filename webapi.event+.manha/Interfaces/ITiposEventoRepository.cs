using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface ITiposEventoRepository
    {
        void Cadastrar(TiposEvento evento);

        List<TiposEvento> ListarEvento();

        void Deletar(Guid id);

        void Atualizar (TiposEvento evento, Guid id);

        TiposEvento BuscarPorId(Guid id);


    }
}
