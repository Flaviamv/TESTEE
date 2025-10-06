using SistemVenda.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using SistemVenda.Dominio.Entidade;

namespace SistemVenda.Repositorio.Entidades 
{
   public class RepositorioCliente : Repositorio<Cliente>
        //, IRepositorioCliente //TO-DO: Arrumar
    {
        public RepositorioCliente(DbContext dbContext) : base(dbContext) { }

    }
}
