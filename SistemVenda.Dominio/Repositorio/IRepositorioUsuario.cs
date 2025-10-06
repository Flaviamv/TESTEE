using SistemVenda.Dominio.Entidade;

namespace SistemVenda.Dominio.Repositorio 
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public bool ValidarLogin(string email, string senha);
    }
}
