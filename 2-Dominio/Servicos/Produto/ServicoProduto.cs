using Dominio.Interfaces;
using Dominio.Repositorio;
using SistemVenda.Dominio.Entidade;


namespace Dominio.Servicos.Produto
{
    public class ServicoProduto : IServicosProduto
    {
        IRepositorioProduto RepositorioProduto;
        public ServicoProduto(IServicosProduto repositorioProduto)
        {
            RepositorioProduto= repositorioProduto;
        }

        public void Cadastrar(Produto produto)
        {
            RepositorioProduto.Cadastrar(produto);
        }

        public Produto CarregarRegistro(int id)
        {
            return RepositorioProduto.CarregarRegistro(id);
        }

        public void Excluir(int id)
        {
            RepositorioProduto.Excluir(id);
        }

        public IEnumerable<Produto> Listagem()
        {

            return RepositorioProduto.Read();
        }
    }
}