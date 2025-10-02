using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemVenda.Models;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCategoria
    {
        public IEnumerable<CategoriaViewModel> Listagem();
    }
}