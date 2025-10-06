using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemVenda.Models;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCategoria
    {
        IEnumerable<SelectListItem> ListaCategoriasDropDownList();
        public IEnumerable<CategoriaViewModel> Listagem();
        void Cadastrar(CategoriaViewModel entidade);
        CategoriaViewModel CarregarRegistro(object codigoCategoria);
        void Excluir(int id);
    


    }
}