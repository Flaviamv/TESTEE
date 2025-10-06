using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemVenda.Models;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCliente
    {
        IEnumerable<SelectListItem> ListaClienteDropDownList();

        IEnumerable<ClienteViewModel> ListaClientesDropDownList();
        void Cadastrar(ClienteViewModel cliente);
        ClienteViewModel CarregarRegistro(int codigoCliente);
        void Excluir(int id);
    public List<ClienteViewModel> Listagem();


    }
}