using Dominio.Interfaces;
using Dominio.Repositorio;
using SistemVenda.Dominio.Entidade;

namespace Dominio.Servicos.categoria
{
    public class ServicoCategoria : IServicosCategoria
    {
        IRepositorioCategoria RepositorioCategoria;
        public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
        {
            RepositorioCategoria = repositorioCategoria;
        }

        public void Cadastrar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Categoria CarregarRegistro(int id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> Listagem()
        {

           throw new NotImplementedException();


        }
    }
}