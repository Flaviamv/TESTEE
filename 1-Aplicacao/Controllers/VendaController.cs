using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SistemVenda.DAL;
using SistemVenda.Entidade;
using SistemVenda.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace SistemVenda.Controllers
{
    [Route("Venda")]
    public class VendaController : Controller
    {
        protected DAL.ApplicationDbContext mContext;

        public VendaController(ApplicationDbContext context)
        {
            mContext = context;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            IEnumerable<Venda> lista = mContext.Venda.ToList();
            mContext.Dispose();
            return View(lista);
        }

        [HttpGet("Listaprodutos")]
        private IEnumerable<SelectListItem> ListaProdutos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in mContext.Produto.ToList())
            {

                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao.ToString()
                });
            }

            return lista;
        }

        [HttpGet("ListaClientes")]
        private IEnumerable<SelectListItem> ListaClientes()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in mContext.Cliente.ToList())
            {

                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome.ToString()
                });
            }

            return lista;
        }

        [HttpGet("Cadastro/{id?}")]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new VendaViewModel();
            viewModel.ListaClientes = ListaClientes();
            viewModel.ListaProdutos = ListaProdutos();

            if (id != null)
            {
                var entidade = mContext.Venda.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Data = entidade.Data;
                viewModel.CodigoCliente = entidade.CodigoCliente;
                viewModel.Total = entidade.Total;

            }

            return View(viewModel);
        }

        [HttpPost("Cadastro")]
        public IActionResult Cadastro([FromBody] VendaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Venda objVenda = new Venda()
                {
                    Codigo = entidade.Codigo,
                    Data = (DateTime)entidade.Data,
                    CodigoCliente = (int)entidade.CodigoCliente,
                    Total = (decimal)entidade.Total,
                    Produtos = JsonConvert.DeserializeObject<ICollection<VendaProduto>>(entidade.JsonProdutos)
                };

                if (entidade.Codigo == null)
                {
                    mContext.Venda.Add(objVenda);
                }
                else
                {
                    mContext.Entry(objVenda).State = EntityState.Modified;
                }

                mContext.SaveChanges();
            }
            else
            {
                entidade.ListaClientes = ListaClientes();
                entidade.ListaProdutos = ListaProdutos();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Excluir/{id}")]
        public IActionResult Excluir([FromRoute] int id)
        {
            var ent = new Venda() { Codigo = id };
            mContext.Attach(ent);
            mContext.Remove(ent);
            mContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("LerValorProduto/{CodigoProduto}")]
        public IActionResult LerValorProduto([FromRoute] int CodigoProduto)
        {
            var request = HttpContext.Request;
            var obj = mContext.Produto.Where(x => x.Codigo == CodigoProduto).Take(1).FirstOrDefault();
            var valor = obj?.Valor;

            return Json(new ApiResponse<decimal>(valor ?? 0));
        }

    }
}
