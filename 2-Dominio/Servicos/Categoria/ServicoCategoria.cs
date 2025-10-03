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
            RepositorioCategoria.Create(categoria);
        }

        public Categoria CarregarRegistro(int id)
        {
            return RepositorioCategoria.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioCategoria.Delete(id);
        }

        public IEnumerable<Categoria> Listagem()
        {

           throw new NotImplementedException();


        }
    }
}