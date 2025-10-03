using Aplicacao.Servico.Interfaces;
using System;
using SistemVenda.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemVenda.Entidade;
using SistemVenda.Dominio.Entidade;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {
        private readonly IServicoAplicacaoProduto _servicoProduto;

        public ServicoAplicacaoProduto(IServicoAplicacaoProduto servicoProduto)
        {
            _servicoProduto = servicoProduto;
        }

        public void Cadastrar(ProdutoViewModel produto)
        {
            ProdutoViewModel produto1 = new ProdutoViewModel()
            {
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                Quantidade = produto.Quantidade,
                Valor = (decimal)produto.Valor,
                CodigoCategoria = (int)produto.CodigoCategoria
            };

            _servicoProduto.Cadastrar(produto1);

        }

        public ProdutoViewModel CarregarRegistro(object codigoProduto)
        {
            if (codigoProduto == null) return new ProdutoViewModel();

            var registro = _servicoProduto.CarregarRegistro(codigoProduto);

            ProdutoViewModel produto = new ProdutoViewModel()
            {
                Codigo = registro.Codigo,
                Descricao = registro.Descricao,
                Quantidade = registro.Quantidade,
                Valor = (decimal)registro.Valor,
                CodigoCategoria = (int)registro.CodigoCategoria
            };

            return produto;
        }

        public void Excluir(int id)
        {
            _servicoProduto.Excluir(id);
        }

        public IEnumerable<ProdutoViewModel> Listagem()
        {
            var lista = _servicoProduto.Listagem();
            List<ProdutoViewModel> listaProduto = new List<ProdutoViewModel>();

            foreach (var item in lista)
            {
                ProdutoViewModel produto = new ProdutoViewModel()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao,
                    Quantidade = item.Quantidade,
                    Valor = (decimal)item.Valor,
                    CodigoCategoria = (int)item.CodigoCategoria
                };
                listaProduto.Add(produto);
            }
            return listaProduto;
        }
    }
}
