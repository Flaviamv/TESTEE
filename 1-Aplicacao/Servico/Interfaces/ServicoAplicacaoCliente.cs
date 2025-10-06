using Microsoft.AspNetCore.Mvc.Rendering;
using SistemVenda.Aplicacao.Servico.Interfaces;
using SistemVenda.Dominio.Entidade;
using SistemVenda.Dominio.Interfaces;
using SistemVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemVenda.Aplicacao.Servico
{
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {
        private readonly IServicosCliente _servicoCliente;

        public ServicoAplicacaoCliente(IServicosCliente servicoCliente)
        {
            _servicoCliente = servicoCliente;
        }

        public IEnumerable<SelectListItem> ListaClienteDropDownList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();
            var lista = this.Listagem();

            foreach (var item in lista)
            {
                SelectListItem cliente = new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome
                };
                retorno.Add(cliente);
            }
            return retorno;
        }

        public IEnumerable<ClienteViewModel> ListaClientesDropDownList()
        {
            var lista = this.Listagem();
            List<ClienteViewModel> retorno = new List<ClienteViewModel>();

            foreach (var item in lista)
            {
                ClienteViewModel cliente = new ClienteViewModel()
                {
                    Codigo = item.Codigo,
                    Nome = item.Nome
                };
                retorno.Add(cliente);
            }
            return retorno;
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

        public ClienteViewModel CarregarRegistro(int codigoCliente)
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

        public List<ClienteViewModel> Listagem()
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
