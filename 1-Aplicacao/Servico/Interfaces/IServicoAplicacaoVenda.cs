using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemVenda.Controllers;
using SistemVenda.Dominio.DTO;
using SistemVenda.Models;

namespace SistemVenda.Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoVenda
    {
        void Cadastrar(VendaViewModel venda);
        VendaViewModel CarregarRegistro(int codigoVenda);
        void Excluir(int id);
        List<VendaViewModel> Listagem();

        IEnumerable<GraficoViewModel> ListaGrafico();


    }
}