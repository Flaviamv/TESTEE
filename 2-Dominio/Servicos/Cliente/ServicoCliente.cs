using SistemVenda.Dominio.Entidade;
using System;
using System.Collections.Generic;

namespace SistemVendas.Dominio.Servicos
{
    public class ServicoCliente : IServicosCliente
    {
        IServicosCliente _servicosCliente;
        public ServicoCliente(IServicosCliente servicosCliente)
        {
            _servicosCliente = servicosCliente;
        }
    

        public void Cadastrar(Cliente cliente)
        {
            _servicosCliente.Cadastrar(cliente);
        }

        public Cliente CarregarRegistro(int id)
        {
            return _servicosCliente.CarregarRegistro(id);
        }

        public void Excluir(int id)
        {
            _servicosCliente.Excluir(id);
        }

        public IEnumerable<Cliente> Listagem()
        {

           throw new NotImplementedException();


        }
    }
}