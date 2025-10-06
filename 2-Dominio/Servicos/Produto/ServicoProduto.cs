using SistemVenda.Dominio.Entidade;
using SistemVenda.Dominio.Interfaces;
using SistemVenda.Dominio.Repositorio;


namespace SistemVenda.Dominio.Servicos
{
    public class ServicoProduto : IServicosProduto
    {
        IRepositorioProduto RepositorioProduto;
        public ServicoProduto(IRepositorioProduto repositorioProduto)
        {
            RepositorioProduto = repositorioProduto;
        }

        public void Cadastrar(Produto produto)
        {
            RepositorioProduto.Create(produto);
        }

        public Produto CarregarRegistro(int id)
        {
            return RepositorioProduto.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioProduto.Delete(id);
        }

        public IEnumerable<Produto> Listagem()
        {
            return RepositorioProduto.Read();
        }
    }
}