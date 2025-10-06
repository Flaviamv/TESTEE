using Microsoft.EntityFrameworkCore;
using SistemVenda.Dominio.Entidade;
using SistemVenda.Dominio.Repositorio;


namespace SistemVenda.Repositorio.Entidades 
{
   public class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(ApplicationDbContext dbContext) : base(dbContext) { }

    
    }
}
