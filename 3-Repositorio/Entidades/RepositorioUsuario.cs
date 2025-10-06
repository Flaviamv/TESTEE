using Microsoft.EntityFrameworkCore;
using SistemVenda.Dominio.Entidade;
using SistemVenda.Models;
using SistemVenda.Repositorio;
using SistemVenda.Repositorio.Entidades;

namespace SistemVenda.Repositorio.Entidades
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
