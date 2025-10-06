using SistemVenda.Dominio.Repositorio;
using SistemVenda.Dominio.Entidade;
using SistemVenda.Models;

namespace SistemVenda.Repositorio.Entidades 
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public bool ValidarLogin(string email, string senha);
    }
}
