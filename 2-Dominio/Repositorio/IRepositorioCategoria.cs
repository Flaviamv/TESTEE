using System;
using System.Collections.Generic;
using System.Text;
using SistemVenda.Dominio.Entidade;

namespace Dominio.Repositorio
{
    public interface IRepositorioCategoria : IRepositorio<Categoria>
    {
        void Delete(int id);

        public IEnumerable<object> Read();
        Categoria Read(int id);
        void Create(Categoria categoria);
    }

    public interface IRepositorio<T>
    {
    }
}