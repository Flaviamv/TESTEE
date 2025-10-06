using SistemVenda.Dominio.Interfaces;
using SistemVenda.Dominio.Entidade;
using SistemVenda.Dominio.Repositorio;


namespace SistemVenda.Dominio.Servicos
{
    public class ServicoProduto //: IServicosProduto //TO-DO: Arrumar
    {
        IRepositorioproduto RepositorioProduto;
        public ServicoProduto(IRepositorioproduto repositorioProduto)
        {
            RepositorioProduto= repositorioProduto;
        }

    //    public void Cadastrar(Produto produto)
    //    {
    //        RepositorioProduto.Cadastrar(produto);
    //    }

    //    public Produto CarregarRegistro(int id)
    //    {
    //        return RepositorioProduto.CarregarRegistro(id);
    //    }

    //    public void Excluir(int id)
    //    {
    //        RepositorioProduto.Excluir(id);
    //    }

    //    public IEnumerable<Produto> Listagem()
    //    {

    //        return RepositorioProduto.Read();
    //    }
    }
}