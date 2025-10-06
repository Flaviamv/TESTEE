using SistemVenda.Dominio.Repositorio;
using SistemVenda.Dominio.Entidade;

namespace SistemVenda.Dominio.Interfaces
{
    public interface IServicoUsuario : IServicoCRUD<Usuario>
    {
        public bool ValidarLogin(string email, string senha);
    }
}
