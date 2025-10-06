using SistemVenda.Dominio.Entidade;
using SistemVenda.Dominio.Interfaces;
using SistemVenda.Dominio.Repositorio;
using System;
using System.Collections.Generic;

namespace SistemVenda.Dominio.Servicos
{
    public class ServicoCliente : IServicosCliente
    {
        IRepositorioCliente _servicosCliente;
        public ServicoCliente(IRepositorioCliente servicosCliente)
        {
            _servicosCliente = servicosCliente;
        }
    

        public void Cadastrar(Cliente cliente)
        {
            _servicosCliente.Create(cliente);
        }

        public Cliente CarregarRegistro(int id)
        {
            return _servicosCliente.Read(id);
        }

        public void Excluir(int id)
        {
            _servicosCliente.Delete(id);
        }

        public IEnumerable<Cliente> Listagem()
        {

            return _servicosCliente.Read();


        }
    }
}