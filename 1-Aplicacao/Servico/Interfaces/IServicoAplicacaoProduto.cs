using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemVenda.Models;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoProduto
    {
        void Cadastrar(ProdutoViewModel produto);
        ProdutoViewModel CarregarRegistro(object codigoProduto);
        void Excluir(int id);
        IEnumerable<SelectListItem> ListaProdutoDropDownList();
         
        IEnumerable<SelectListItem> ListaClienteDropDownList();
        string? Listagem();
    }
}