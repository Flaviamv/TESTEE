using System;
using System.Collections.Generic;
using System.Text;
using SistemVenda.Dominio.Entidade;
using SistemVendas.Models;

namespace Dominio.Repositorio
{
    public interface IRepositorioVendaProdutos
    {
        IEnumerable<GraficoViewModel> ListaGrafico();
    }
 
}