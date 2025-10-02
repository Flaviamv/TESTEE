using Aplicacao.Servico.Interfaces;
using System;
using SistemVenda.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private readonly IServicoAplicacaoCategoria _servicoCategoria;

    public ServicoAplicacaoCategoria(IServicoAplicacaoCategoria servicoCategoria)
        {
            _servicoCategoria = servicoCategoria;
        }

         public IEnumerable<CategoriaViewModel> Listagem()
        {
            var lista = _servicoCategoria.Listagem();
            List<CategoriaViewModel> listaCategoria = new List<CategoriaViewModel>();

            foreach (var item in lista)
            {
                 CategoriaViewModel categoria = new CategoriaViewModel()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao
                };
                listaCategoria.Add(categoria);
            }
            return listaCategoria;
        }
    }


}