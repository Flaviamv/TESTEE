using System;
using System.Collections.Generic;
using System.Text;
using SistemVenda.Dominio.Entidade;

namespace Dominio.Repositorio
{
    public interface IRepositorioproduto : IRepositorio<Produto>
    {
         IEnumerable<Produto> Read();
    }
}