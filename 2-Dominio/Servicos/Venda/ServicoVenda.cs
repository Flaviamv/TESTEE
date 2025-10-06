using SistemVenda.Dominio.Entidade;
using SistemVenda.Dominio.Interfaces;
using SistemVenda.Dominio.Repositorio;
using SistemVenda.Dominio.DTO;
using System;
using System.Collections.Generic;


namespace SistemVenda.Dominio.Servicos
{
    public class ServicoVenda : IServicosVenda
    {
        IRepositorioVenda RepositorioVenda;
        IRepositorioVendaProdutos RepositorioVendaProdutos;

        public ServicoVenda(IRepositorioVenda repositorioVenda,
        IRepositorioVendaProdutos repositorioVendaProduto)
        {
            RepositorioVenda = repositorioVenda;
            RepositorioVendaProdutos = repositorioVendaProduto;
        }
    

        public void Cadastrar(Venda venda)
        {
            RepositorioVenda.Create(venda);
        }

        public Venda CarregarRegistro(int id)
        {
            return RepositorioVenda.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioVenda.Delete(id);
        }

        public IEnumerable<Venda> Listagem()
        {

           return RepositorioVenda.Read();

        }

        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            return RepositorioVendaProdutos.ListaGrafico();
        }
    }
}