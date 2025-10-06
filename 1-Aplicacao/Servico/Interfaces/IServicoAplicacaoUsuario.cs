using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemVenda.Models;

namespace SistemVenda.Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoUsuario
    {
         bool ValidarLogin(string email, string senha);

        Usuario RetornarDadosUsuario(string email, string senha);
        // IEnumerable<Usuario> Listagem();
    }
}