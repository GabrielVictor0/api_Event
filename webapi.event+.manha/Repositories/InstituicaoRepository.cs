using Microsoft.AspNetCore.Http.HttpResults;
using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Instituicao instituicaoAtualizada)
        {
            Instituicao instituicaoBuscada = _eventContext.Instituicao.Find(id)!;

            if (instituicaoBuscada != null)
            {
                instituicaoBuscada.CNPJ = instituicaoAtualizada.CNPJ;

                instituicaoBuscada.NomeFantasia = instituicaoAtualizada.NomeFantasia;

                instituicaoBuscada.Endereco = instituicaoAtualizada.Endereco;
            }

            _eventContext.Instituicao.Update(instituicaoBuscada!);

            _eventContext.SaveChanges();

        }

        public Instituicao BuscarPorId(Guid id)
        {
            return _eventContext.Instituicao.FirstOrDefault(i => i.IdInstituicao == id)!;
        }

        public void Cadastrar(Instituicao instituicaoNova)
        {
            _eventContext.Instituicao.Add(instituicaoNova);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Instituicao instituicaoBuscada = _eventContext.Instituicao.Find(id)!;

            if (instituicaoBuscada != null)
            {
                _eventContext.Instituicao.Remove(instituicaoBuscada);
            }

            _eventContext.SaveChanges();
        }

        public List<Instituicao> ListarInstituicao()
        {
            List<Instituicao> ListaInstituicao = _eventContext.Instituicao.ToList();

            return ListaInstituicao;
        }
    }
}
