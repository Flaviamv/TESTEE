using SistemVenda.Dominio.Entidade;
using SistemVenda.Dominio.Interfaces;
using SistemVenda.Dominio.Repositorio;
using SistemVendas.Models;
using System;
using System.Collections.Generic;

namespace SistemVenda.Dominio.Servicos
{
    public class ServicoVenda : IServicosVenda
    {
        IServicosVenda _servicosCliente;
        private IServicosVenda _servicosVenda;

        public ServicoVenda(IServicosVenda servicosVenda,
        IRepositorioVendaProdutos RepositorioVendaProduto)
        {
            _servicosVenda = servicosVenda;
        }
    

        public void Cadastrar(Venda venda)
        {
            _servicosVenda.Cadastrar(venda);
        }

        public Venda CarregarRegistro(int id)
        {
            return _servicosVenda.CarregarRegistro(id);
        }

        public void Excluir(int id)
        {
            _servicosVenda.Excluir(id);
        }

        public IEnumerable<Venda> Listagem()
        {

           throw new NotImplementedException();

        }

        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            //TO-DO: Arrumar
            //return RepositorioVendaProduto.ListaGrafico();
            return new List<GraficoViewModel>();
        }
    }
}