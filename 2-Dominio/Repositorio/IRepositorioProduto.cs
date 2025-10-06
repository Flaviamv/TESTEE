using System;
using System.Collections.Generic;
using System.Text;
using SistemVenda.Dominio.Entidade;

namespace SistemVenda.Dominio.Repositorio
{
    public interface IRepositorioProduto : IRepositorio<Produto>
    {
        new public IEnumerable<Produto> Read();
    }
}