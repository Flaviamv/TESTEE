using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemVendas.Dominio.DTO
{
    public class GraficoViewModel
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public double TotalVendido { get; set; }
    }
}