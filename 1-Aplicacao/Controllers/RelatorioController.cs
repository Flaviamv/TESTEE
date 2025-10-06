using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using SistemVenda.Aplicacao.Servico.Interfaces;
using SistemVenda.Repositorio;


namespace SistemVenda.Controllers
{
    public class RelatorioController : Controller
    {
        readonly IServicoAplicacaoVenda ServicoVenda;
        protected ApplicationDbContext mContext;

        public RelatorioController(IServicoAplicacaoVenda servicoVenda)
        {
            ServicoVenda = servicoVenda;
        }
        public IActionResult Grafico()
        {
            var lista = ServicoVenda.ListaGrafico().ToList();
            var random = new Random();

                string valores = "";
                string labels = "";
                string cores = "";

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