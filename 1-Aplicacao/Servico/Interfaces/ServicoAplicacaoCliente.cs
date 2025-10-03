using SistemVenda.Dominio.Entidade;
using System;
using System.Collections.Generic;
using Dominio.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {
        private readonly IServicoCliente _servicoCliente;

        public ServicoAplicacaoCliente(IServicoCliente servicoCliente)
        {
            _servicoCliente = servicoCliente;
        }

        public void Cadastrar(ClienteViewModel cliente)
        {
            Cliente item = new Cliente()
            {
                Codigo = cliente.Codigo,
                Nome = cliente.Nome,
                CNPJ_CPF = cliente.CNPJ_CPF,
                Celular = cliente.Celular,
                Email = cliente.Email
            };

            _servicoCliente.Cadastrar(item);
        }

        public ClienteViewModel CarregarRegistro(int codigoClidente)
        {
            var registro = _servicoCliente.CarregarRegistro(codigoCliente);

            ClienteViewModel cliente = new ClienteViewModel()
            {
                Codigo = registro.Codigo,
                Nome = registro.Nome,
                CNPJ_CPF = registro.CNPJ_CPF,
                Celular = registro.Celular,
                Email = registro.Email
            };
            return cliente;
        }

        public void Excluir(int codigoCliente)
        {
            _servicoCliente.Excluir(codigoCliente);
        }

        public IEnumerable<ClienteViewModel> Listagem()
        {
            var lista = _servicoCliente.Listagem();

            List<ClienteViewModel> listaCliente = new List<ClienteViewModel>();

            foreach (var item in lista)
            {
                listaCliente.Add(new ClienteViewModel()
                {
                    Codigo = item.Codigo,
                    Nome = item.Nome,
                    CNPJ_CPF = item.CNPJ_CPF,
                    Celular = item.Celular,
                    Email = item.Email
                });
            }
            return listaCliente;

        }
    }
}