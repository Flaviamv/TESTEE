using Dominio.Repositorio;
using SistemVenda.Dominio.Entidade;

namespace SistemVenda.Repositorio.Entidades 
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public bool ValidarLogin(string email, string senha);
    }
}
