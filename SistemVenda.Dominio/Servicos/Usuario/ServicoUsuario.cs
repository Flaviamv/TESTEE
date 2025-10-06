using SistemVenda.Dominio.Interfaces;
using SistemVenda.Dominio.Repositorio;
using SistemVenda.Dominio.Entidade;

namespace SistemVenda.Dominio.Servicos.ServicoUsuario
{
    public class ServicoUsuario : IServicosUsuario
    {
        IRepositorioUsuario RepositorioUsuario;
        public ServicoUsuario(IRepositorioUsuario repositorioUsuario) //construtor
        {
            RepositorioUsuario = repositorioUsuario;
        }

        public void Cadastrar(Usuario usuario)
        {
            RepositorioUsuario.Create(usuario);
        }

        public Usuario CarregarRegistro(int id) //func 
        {
            return RepositorioUsuario.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioUsuario.Delete(id);
        }

        public IEnumerable<Usuario> Listagem()
        {
            throw new NotImplementedException();
        }

        public bool ValidarLogin(string email, string senha)
        {
            return RepositorioUsuario.ValidarLogin(email, senha);
        }
    }

    public interface IServicosUsuario
    {
    }

}