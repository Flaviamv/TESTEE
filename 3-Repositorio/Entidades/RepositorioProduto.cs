using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using SistemVenda.Dominio.Entidade;

namespace Repositorio.Entidades 
{
    public class RepositorioProduto : Repositorio<Produto>, IRepositorioproduto
    {
        public RepositorioProduto(DbContext dbContext) : base(dbContext)
        {

        }

        public override IEnumerable<Produto> Read()
        {
            return _dbSet.Include(x => x.Categoria).AsNoTracking().ToList();
        }
    }
}
