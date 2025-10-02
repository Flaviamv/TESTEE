using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using SistemVenda.Dominio.Entidade;

namespace Repositorio.Entidades 
{
   public class RepositorioCategoria : Repositorio<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoria(DbContext dbContext) : base(dbContext) { }

        IEnumerable<object> IRepositorioCategoria.Read()
        {
            throw new NotImplementedException();
        }
    }
}
