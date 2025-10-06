using Microsoft.EntityFrameworkCore;
using SistemVenda.Dominio.Entidade;
using SistemVenda.Dominio.Repositorio;
using SistemVenda.Repositorio;

namespace SistemVenda.Repositorio.Entidades 
{
    public class RepositorioProduto : Repositorio<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(ApplicationDbContext dbContext) : base(dbContext)
        {
 
        }

        public override IEnumerable<Produto> Read()
        {
            return _dbSet.Include(x => x.Categoria).AsNoTracking().ToList();
        }
    }
}
