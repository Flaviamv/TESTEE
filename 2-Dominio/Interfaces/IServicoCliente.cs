using SistemVenda.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemVenda.Dominio.Interfaces
{
    public interface IServicosCliente : IServicoCRUD<Cliente>
    {
        IEnumerable<Cliente> Listagem();
        void Cadastrar(Cliente cliente);
        Cliente CarregarRegistro(int id);
        void Excluir(int id);
    }
}
