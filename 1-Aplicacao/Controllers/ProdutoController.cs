using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Servico;
using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemVenda.Entidade;
using SistemVenda.Models;

namespace SistemVenda.Controllers
{
    public class ProdutoController : Controller
    {
        readonly IServicoAplicacaoProduto ServicoAplicacao;
        readonly IServicoAplicacaoCategoria ServicoAplicacaoCategoria;

        public ProdutoController(
            IServicoAplicacaoProduto servicoAplicacao,
            IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            ServicoAplicacao = servicoAplicacao;
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacao.Listagem());
        }

        public IActionResult Cadastro(int? id)
        {
            ProdutoViewModel viewModel = new ProdutoViewModel(); 

            if (id != null)
            {
                viewModel = ServicoAplicacao.CarregarRegistro((int)id);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                {
                    ServicoAplicacao.Cadastrar(entidade);
                }
            }

            else
            {
                ProdutoViewModel viewModel = new ProdutoViewModel();
                viewModel.ListaCategorias = ServicoAplicacaoCategoria.ListaCategoriasDropDownList();
                return View(entidade);
            }

                return RedirectToAction("Index");
            }

            [HttpDelete]
            public IActionResult Excluir([FromRoute] int id)
            {
                ServicoAplicacaoCategoria.Excluir(id);
                return RedirectToAction("Index");
            }
        }
    }
