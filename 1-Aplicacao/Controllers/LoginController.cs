using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemVenda.Aplicacao.Servico.Interfaces;
using SistemVenda.Helpers;
using SistemVenda.Models;


namespace SistemVenda.Controllers
{
    public class LoginController : Controller
    {
         protected IHttpContextAccessor HttpContextAcessor;
        readonly IServicoAplicacaoUsuario ServicoAplicacaoUsuario;

        public LoginController(IServicoAplicacaoUsuario servicoAplicacaoUsuario, IHttpContextAccessor httpContext)
        {
            ServicoAplicacaoUsuario = servicoAplicacaoUsuario;
            HttpContextAcessor = httpContext;
        }

        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContextAcessor.HttpContext.Session.Clear();
                    
                }
            }
            return View();
        }


        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            ViewData["ErroLogin"] = string.Empty;

            if (ModelState.IsValid)  //verificacao se esta valido
            {
                var Senha = Criptografia.GetMd5Hash(model.Senha);

                bool login = ServicoAplicacaoUsuario.ValidarLogin(model.Email, Senha);

                if (login)
                {
                    //colocar os dados do usuario na sessao
                    var Usuario = ServicoAplicacaoUsuario.RetornarDadosUsuario(model.Email, Senha);
                    HttpContextAcessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, Usuario.Nome);
                    HttpContextAcessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, Usuario.Email);
                    HttpContextAcessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, (int)Usuario.Codigo);
                    HttpContextAcessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewData["ErroLogin"] = "O Email ou senha informado não existe no sistema!";
                    return View(model);

                }
            }
            else
            {
                return View(model);
            }
        }
    }
}