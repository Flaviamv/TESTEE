using SistemVenda.Dominio.Entidade;
using SistemVendas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IServicosVenda : IServicoCRUD<Venda>
    {
        IEnumerable<GraficoViewModel> ListaGrafico();
    }
}
