using System;
using SistemVenda.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemVenda.Aplicacao.Servico.Interfaces;
using SistemVenda.Dominio.Interfaces;
using SistemVenda.Dominio.Servicos;
using SistemVenda.Dominio.Entidade;


namespace SistemVenda.Aplicacao.Servico
{
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {
        private readonly IServicosProduto _servicoProduto;

        public ServicoAplicacaoProduto(IServicosProduto servicoProduto)
        {
            _servicoProduto = servicoProduto;
        }

        public IEnumerable<SelectListItem> ListaProdutoDropDownList()
        {
            var lista = _servicoProduto.Listagem();

            List<SelectListItem> ListaProduto = new List<SelectListItem>();

            foreach (var item in lista)
            {
                SelectListItem produto = new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                };
                ListaProduto.Add(produto);

            }
            return ListaProduto;
        }

        public void Cadastrar(ProdutoViewModel produto)
        {
            Produto produto1 = new Produto()
            {
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                Quantidade = (int)produto.Quantidade,
                Valor = (decimal)produto.Valor,
                CodigoCategoria = (int)produto.CodigoCategoria
            };

            _servicoProduto.Cadastrar(produto1);

        }

        public ProdutoViewModel CarregarRegistro(int codigoProduto)
        {
            if (codigoProduto == 0) return new ProdutoViewModel();

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
