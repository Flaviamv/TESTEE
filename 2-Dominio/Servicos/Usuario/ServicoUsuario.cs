using SistemVenda.Dominio.Entidade;
using SistemVenda.Dominio.Interfaces;
using SistemVenda.Models;
using SistemVenda.Repositorio.Entidades;

namespace SistemVenda.Dominio.Servicos
{
    public class ServicoUsuario : IServicoUsuario
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
            return RepositorioUsuario.Read();
        }

        public bool ValidarLogin(string email, string senha)
        {
            return RepositorioUsuario.ValidarLogin(email, senha);
        }
    }

}