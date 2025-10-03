using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using SistemVenda.Dominio.Entidade;


namespace Repositorio.Entidades 
{
   public class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(DbContext dbContext) : base(dbContext) { }

    
    }
}
