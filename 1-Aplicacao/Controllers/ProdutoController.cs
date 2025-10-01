using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        protected ApplicationDbContext mContext;

        public ProdutoController(ApplicationDbContext context)
        {
            mContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Produto> lista = mContext.Produto.Include(p=> p.Categoria).ToList();
            mContext.Dispose();
            return View(lista);
        }

        private IEnumerable<SelectListItem> ListaCategoria()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in mContext.Categoria.ToList())
            {

                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao.ToString()
                });
            }

            return lista;
        }

        [HttpGet] //renderiza tela vazia 
        public IActionResult Cadastro(int? id)
        {
            ProdutoViewModel viewModel = new ProdutoViewModel();
            viewModel.ListaCategorias = ListaCategoria();

            if (id != null)
            {
                var entidade = mContext.Produto.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;
                viewModel.Quantidade = entidade.Quantidade;
                viewModel.Valor = entidade.Valor;
                viewModel.CodigoCategoria = entidade.CodigoCategoria;

            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Produto objProduto = new Produto()
                {
                    Codigo = entidade.Codigo,
                    Descricao = entidade.Descricao,
                    Quantidade = (float)entidade.Quantidade,
                    Valor = (decimal)entidade.Valor,
                    CodigoCategoria = (int)entidade.CodigoCategoria
                };

                if (entidade.Codigo == null)
                {
                    mContext.Produto.Add(objProduto);
                }
                else
                {
                    mContext.Entry(objProduto).State = EntityState.Modified;
                }

                mContext.SaveChanges();
            }
            else
            {
                entidade.ListaCategorias = ListaCategoria();
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