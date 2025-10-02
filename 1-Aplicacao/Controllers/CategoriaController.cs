using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemVenda.DAL;
using SistemVenda.Entidade;
using SistemVenda.Models;

namespace SistemVenda.Controllers
{
    public class CategoriaController : Controller
    {
        readonly IServicoAplicacaoCategoria ServicoAplicacaoCategoria;

        public CategoriaController(IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacaoCategoria.Listagem());
        }
    }
}

//         [HttpGet] //renderizar tela vazia 
//         public IActionResult Cadastro(int? id)
//         {
//             CategoriaViewModel viewModel = new CategoriaViewModel();

//             if (id != null)
//             {
//                 var entidade = mContext.Categoria.Where(x => x.Codigo == id).FirstOrDefault();
//                 viewModel.Codigo = entidade.Codigo;
//                 viewModel.Descricao = entidade.Descricao;

//             }

//             return View(viewModel);
//         }

//         [HttpPost]
//         public IActionResult Cadastro(CategoriaViewModel entidade)
//         {
//             if (ModelState.IsValid)
//             {
//                 Categoria objCategoria = new Categoria()
//                 {
//                     Codigo = (entidade.Codigo != null) ? (int)entidade.Codigo : 0,
//                     Descricao = entidade.Descricao
//                 };

//                 if (entidade.Codigo == null)
//                 {
//                     mContext.Categoria.Add(objCategoria);
//                 }
//                 else
//                 {
//                     mContext.Entry(objCategoria).State = EntityState.Modified;
//                 }

//                 mContext.SaveChanges();
//             }
//             else
//             {
//                 return View(entidade);
//             }

//             return RedirectToAction("Index");
//         }

//         [HttpDelete] 
//         public IActionResult Excluir(int id)       //NAO RODA, AO CLICAR ME EXCLUIR NAO EXCLUI (JA OLHEI Pasta ENTIDADADE E Arq CATEGORIA)
//         {
//             var entidade = new Categoria() { Codigo = id };
//             mContext.Attach(entidade);
//             mContext.Remove(entidade);
//             return Json(new ApiResponse<bool>(mContext.SaveChanges() > 0));
//         }
//     }
// }