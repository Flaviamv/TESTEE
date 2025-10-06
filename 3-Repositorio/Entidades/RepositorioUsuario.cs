using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using _3_Repositorio.Entidades;
using SistemVenda.Dominio.Entidade;

namespace Repositorio.Entidades
{
   public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(ApplicationDbContext dbContext) : base(dbContext) { }

        public bool ValidarLogin(string email, string senha)
        {
            var usuario = _dbSet.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
            return usuario != null;
        
        }
    }
}
