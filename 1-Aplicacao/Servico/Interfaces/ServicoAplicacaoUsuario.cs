using Aplicacao.Servico.Interfaces;
using System;
using SistemVenda.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemVenda.Entidade;
using SistemVenda.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Razor.Language;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoUsuario : IServicoAplicacaoUsuario
    {
        private readonly IServicoAplicacaoUsuario _servicoUsuario;

        public ServicoAplicacaoUsuario(IServicoAplicacaoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        public IEnumerable<Usuario> Listagem() {
            return _servicoUsuario.Listagem();
        }

        public Usuario RetornarDadosUsuario(string email, string senha)
        {
            return Listagem().Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
        }

        public bool ValidarLogin(string email, string senha)
        {
            return _servicoUsuario.ValidarLogin(email, senha);
        }
    }
}
    

