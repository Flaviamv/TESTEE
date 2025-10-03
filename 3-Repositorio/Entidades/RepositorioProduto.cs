using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using SistemVenda.Dominio.Entidade;

namespace Repositorio.Entidades 
{
    public class RepositorioProduto : Repositorio<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(DbContext dbContext) : base(dbContext)
        {
                 public override IEnumerable<Produto> Read()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        
        }
    }
}
