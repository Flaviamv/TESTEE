using System;
using System.Collections.Generic;
using System.Text;
using SistemVenda.Dominio.Entidade;
using SistemVendas.Dominio.DTO;

namespace SistemVenda.Dominio.Repositorio
{
    public interface IRepositorioVendaProdutos
    {
        IEnumerable<GraficoViewModel> ListaGrafico();
    }
 
}