using System;
using System.Collections.Generic;
using System.Text;

namespace SistemVenda.Dominio.Repositorio
{
    public interface IRepositorio<TEntidade>
         where TEntidade : class
    {
        public void Create(TEntidade Entity);
        public TEntidade Read(int id);
        public void Delete(int id);
        public IEnumerable<TEntidade> Read();
    }
}
