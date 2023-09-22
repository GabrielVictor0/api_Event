using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IInstituicaoRepository
    {
        void Cadastrar(Instituicao instituicaoNova);

        void Deletar(Guid id);

        List<Instituicao> ListarInstituicao();

        Instituicao BuscarPorId (Guid id);

        void Atualizar (Guid id, Instituicao instituicaoAtualizada);
    }
}
