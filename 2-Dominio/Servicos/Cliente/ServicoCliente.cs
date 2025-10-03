using Dominio.Interfaces;
using Dominio.Repositorio;
using SistemVenda.Dominio.Entidade;
using System;
using System.Collections.Generic;

namespace Dominio.Servicos
{
    public class ServicoCliente : IServicosCliente
    {
        IRepositorioCliente RepositorioCliente;
        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            RepositorioCliente = repositorioCliente;
        }

        public void Cadastrar(Categoria cliente)
        {
            RepositorioCliente.Create(cliente);
        }

        public Cliente CarregarRegistro(int id)
        {
            return RepositorioCliente.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioCliente.Delete(id);
        }

        public IEnumerable<Cliente> Listagem()
        {

           throw new NotImplementedException();


        }
    }
}