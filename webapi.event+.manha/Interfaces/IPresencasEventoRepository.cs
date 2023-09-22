using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IPresencasEventoRepository
    {
        void Cadastrar(PresencasEvento presenca);

        void Deletar(Guid id);

        void Atualizar(Guid id, PresencasEvento presenca);

        List<PresencasEvento> ListaPresenca();

        PresencasEvento ListarMinhaPresenca (Guid id);
    }
}
