using SistemVenda.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Mvc;
using SistemVenda.Aplicacao.Servico.Interfaces;
using SistemVenda.Dominio.Entidade;


namespace SistemVenda.Aplicacao.Servico
{
    public class ServicoAplicacaoUsuario : IServicoAplicacaoUsuario
    {
        private readonly IServicoUsuario _servicoUsuario;

        public ServicoAplicacaoUsuario(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        public Usuario RetornarDadosUsuario(string email, string senha)
        {
            //return Listagem().Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
            var lista = _servicoUsuario;
        }

        public bool ValidarLogin(string email, string senha)
        {
            return _servicoUsuario.ValidarLogin(email, senha);
        }
    }
}
    

