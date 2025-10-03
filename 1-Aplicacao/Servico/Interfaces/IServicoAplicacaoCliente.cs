using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemVenda.Models;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCliente
    {
        void Cadastrar(ClienteViewModel cliente);
        ClienteViewModel CarregarRegistro(object codigoCliente);
        void Excluir(int id);
    public IEnumerable<CategoriaViewModel> Listagem();


    }
}