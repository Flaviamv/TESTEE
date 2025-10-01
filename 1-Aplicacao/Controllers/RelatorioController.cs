using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using SistemVenda.DAL;
using SistemVendas.Models;

namespace SistemVenda.Controllers
{
    public class RelatorioController : Controller
    {
        protected ApplicationDbContext mContext;

        public RelatorioController(ApplicationDbContext context)
        {
            mContext = context;
        }
        public IActionResult Grafico()
        {
            var lista = mContext.VendaProduto
             .GroupBy(x => x.CodigoProduto)
             .Select(y => new GraficoViewModel
             {
                 CodigoProduto = y.First().CodigoProduto,
                 Descricao = y.First().Produto.Descricao,
                 TotalVendido = y.Sum(z => z.QuantidadeProduto)
             }).ToList();

            string valores = string.Empty;
            string labels = string.Empty;
            string cores = string.Empty;

            var random = new Random();

            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].TotalVendido.ToString() + ",";
                labels += lista[i].Descricao.ToString() + ",";
                cores += "'" + String.Format("#(0:x6)", random.Next(0x1000000)) + ",";
            }

            ViewBag.Valores= valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores;

            return View();
        }
    }
}