using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemVenda.Aplicacao.Servico.Interfaces;
using SistemVenda.AplicacaoAplicacao.Servico.Interfaces;
using SistemVenda.Models;

namespace SistemVenda.Controllers
{
    public class VendaController : Controller
    {

        readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;
        readonly IServicoAplicacaoCliente ServicoAplicacaoCliente;
        readonly IServicoAplicacaoVenda ServicoAplicacaoVenda;


        public VendaController(

                IServicoAplicacaoVenda servicoAplicacaoVenda,
                IServicoAplicacaoProduto servicoAplicacaoProduto,
                IServicoAplicacaoCliente servicoAplicacaoCliente)
        {
            ServicoAplicacaoVenda = servicoAplicacaoVenda;
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
        }


        public IActionResult Index()
        {
            return View(ServicoAplicacaoVenda.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new VendaViewModel();

            if (id != null)
            {
                viewModel = ServicoAplicacaoVenda.CarregarRegistro((int)id);
            }

            // ProdutoViewModel viewModel = new ProdutoViewModel();
            viewModel.ListaClientes = ServicoAplicacaoCliente.ListaClienteDropDownList();
            viewModel.ListaProdutos = ServicoAplicacaoProduto.ListaProdutoDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                    ServicoAplicacaoVenda.Cadastrar(entidade);
                }

            else
                    {

                        entidade.ListaClientes = ServicoAplicacaoCliente.ListaClienteDropDownList();
                        entidade.ListaProdutos = ServicoAplicacaoProduto.ListaProdutoDropDownList();
                        return View(entidade);
                    }
                return RedirectToAction("Index");
            }
        [HttpDelete]
            public IActionResult Excluir([FromRoute] int id)
            {
                ServicoAplicacaoVenda.Excluir(id);
                return RedirectToAction("Index");

            }

            [HttpGet("LerValorProduto/{codigo}")]

            public decimal LarValorProduto(int CodigoProduto)
            {
                return (decimal)ServicoAplicacaoProduto.CarregarRegistro(CodigoProduto).Valor;
            }
    }
}
