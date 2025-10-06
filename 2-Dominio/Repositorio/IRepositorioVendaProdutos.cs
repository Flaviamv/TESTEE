using System;
using System.Collections.Generic;
using System.Text;
using SistemVenda.Dominio.Entidade;
using SistemVenda.Dominio.DTO;

namespace SistemVenda.Dominio.Repositorio
{
    public interface IRepositorioVendaProdutos 
    {
        public IEnumerable<GraficoViewModel> ListaGrafico();
    }
 
}