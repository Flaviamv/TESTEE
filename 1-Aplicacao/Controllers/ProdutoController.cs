using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Servico;
using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemVenda.DAL;
using SistemVenda.Entidade;
using SistemVenda.Models;

namespace SistemVenda.Controllers
{
    public class ProdutoController : Controller
    {
        readonly IServicoAplicacaoProduto ServicoAplicacao;

        public ProdutoController(IServicoAplicacaoProduto servico)

        {
            ServicoAplicacao = servico;
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

        [HttpGet] //renderiza tela vazia 
        public IActionResult Cadastro(int? id)
        {
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
                    ServicoAplicacaoProduto.Cadastro(entidade);
                }
            }

            else
            {
                return View(entidade);
            }

                return RedirectToAction("Index");
            }

            [HttpDelete]
            public IActionResult Excluir([FromRoute] int id)
            {
                var ent = new Produto() { Codigo = id };
                mContext.Produto.Remove(ent);
                var success = mContext.SaveChanges() > 0;
                var response = new ApiResponse<bool>(success);
                if (!success)
                    response.Message = "Falha ao excluir produto.";

                return Json(response);
            }
        }
    }
