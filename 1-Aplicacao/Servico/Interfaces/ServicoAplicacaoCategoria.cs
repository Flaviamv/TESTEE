using Aplicacao.Servico.Interfaces;
using System;
using SistemVenda.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemVenda.Entidade;
using SistemVenda.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Razor.Language;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private readonly IServicoAplicacaoCategoria _servicoCategoria;

        public ServicoAplicacaoCategoria(IServicoAplicacaoCategoria servicoCategoria)
        {
            _servicoCategoria = servicoCategoria;
        }

        public void Cadastrar(CategoriaViewModel categoria)
        {
            CategoriaViewModel categoria1 = new CategoriaViewModel()
            {
                Codigo = categoria.Codigo,
                Descricao = categoria.Descricao
            };

            _servicoCategoria.Cadastrar(categoria1);

        }

        public CategoriaViewModel CarregarRegistro(object codigoCategoria)
        {
            if (codigoCategoria == null) return new CategoriaViewModel();

            var registro = _servicoCategoria.CarregarRegistro(codigoCategoria);

            CategoriaViewModel categoria = new CategoriaViewModel()
            {
                Codigo = registro.Codigo,
                Descricao = registro.Descricao
            };

            return categoria;
        }

        public void Excluir(int id)
        {
            _servicoCategoria.Excluir(id);
        }

        public IEnumerable<SelectListItem> ListaCategoriasDropDownList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();

            var lista = this.Listagem();

            foreach (var item in lista)
            {
                SelectListItem categoria = new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                };
                retorno.Add(categoria);
            }
            return retorno;

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
