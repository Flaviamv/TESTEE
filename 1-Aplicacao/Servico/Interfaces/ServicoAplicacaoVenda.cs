using Aplicacao.Servico.Interfaces;
using Newtonsoft.Json;
using SistemVenda.Controllers;
using SistemVenda.Dominio.Entidade;
using SistemVenda.Entidade;
using SistemVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoVenda : IServicoAplicacaoVenda
    {
        private readonly IServicoAplicacaoVenda _servicoVenda;

        public ServicoAplicacaoVenda(IServicoAplicacaoVenda servicoVenda)
        {
            _servicoVenda = servicoVenda;
        }

        public void Cadastrar(VendaViewModel venda)
        {
            VendaViewModel item = new VendaViewModel()
            {
                Codigo = venda.Codigo,
                Data = (DateTime)venda.Data,
                CodigoCliente = (int)venda.CodigoCliente,
                Total = venda.Total,
                Produto = JsonConvert.DeserializeObject<ICollection<VendaProdutoDTO>>(venda.JsonProdutos)
            };

            _servicoVenda.Cadastrar(item);
        }

        public VendaViewModel CarregarRegistro(int codigoVenda)
        {
            var registro = _servicoVenda.CarregarRegistro(codigoVenda);

            VendaViewModel venda = new VendaViewModel()
            {
                Codigo = registro.Codigo,
                Data = (DateTime)registro.Data,
                CodigoCliente = (int)registro.CodigoCliente,
                Total = registro.Total
            };
            return venda;
        }

        public void Excluir(int codigoVenda)
        {
            _servicoVenda.Excluir(codigoVenda);
        }

        public List<VendaViewModel> Listagem()
        {
            var lista = _servicoVenda.Listagem();
            List<VendaViewModel> listaVenda = new List<VendaViewModel>();

            foreach (var item in lista)
            {
                listaVenda.Add(new VendaViewModel()
                {
                    Codigo = item.Codigo,
                    Data = (DateTime)item.Data,
                    CodigoCliente = (int)item.CodigoCliente,
                    Total = item.Total
                });
            }
            return listaVenda;

        }

        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            List<GraficoViewModel> lista = new List<GraficoViewModel>();

            var auxLista = _servicoVenda.ListaGrafico();

            foreach (var item in auxLista)
            {
                GraficoViewModel grafico = new GraficoViewModel()
                {
                    CodigoProduto = item.CodigoProduto,
                    Descricao = item.Descricao,
                    TotalVendido = item.TotalVendido
                };
                lista.Add(grafico);
            }
            return lista;
        }
    }

    internal class Listagem<T>
    {
        public Listagem()
        {
        }
    }
}