using System;
using System.Collections.Generic;
using System.Text;
using SistemVenda.Dominio.Entidade;

namespace Dominio.Repositorio
{
    public interface IRepositorioVenda : IRepositorio<Venda>
    {
        new void Delete (int id);
    }
}