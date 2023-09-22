using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IComentariosEventoRepository
    {
        void Cadastrar(ComentariosEvento comentarioEvento);

        ComentariosEvento BuscarPorId(Guid id);

        List<ComentariosEvento> ListaComentario();

        void Deletar(Guid id);
    }
}
