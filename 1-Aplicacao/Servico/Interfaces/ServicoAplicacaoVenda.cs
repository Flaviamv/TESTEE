using Newtonsoft.Json;
using SistemVenda.Aplicacao.Servico.Interfaces;
using SistemVenda.Controllers;
using SistemVenda.Dominio.DTO;
using SistemVenda.Dominio.Entidade;
using SistemVenda.Dominio.Interfaces;
using SistemVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemVenda.Aplicacao.Servico
{
    public class ServicoAplicacaoVenda : IServicoAplicacaoVenda
    {
        private readonly IServicosVenda _servicoVenda;

        public ServicoAplicacaoVenda(IServicosVenda servicoVenda)
        {
            _servicoVenda = servicoVenda;
        }

        public void Cadastrar(VendaViewModel venda)
        {
            Venda item = new Venda()
            {
                Codigo = venda.Codigo,
                Data = (DateTime)venda.Data,
                CodigoCliente = (int)venda.CodigoCliente,
                Total = venda.Total,
                Produtos = JsonConvert.DeserializeObject<ICollection<VendaProduto>>(venda.JsonProdutos)

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
            return _servicoVenda.ListaGrafico();
        }
    }

    internal class Listagem<T>
    {
        public Listagem()
        {
        }
    }
}