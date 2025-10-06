using System;
using SistemVenda.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Razor.Language;
using SistemVenda.Aplicacao.Servico.Interfaces;
using SistemVenda.Dominio.Interfaces;
using SistemVenda.Dominio.Entidade;

namespace SistemVenda.Aplicacao.Servico
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private readonly IServicosCategoria  _servicoCategoria;

        public ServicoAplicacaoCategoria(IServicosCategoria servicoCategoria)
        {
            _servicoCategoria = servicoCategoria;
        }

        public void Cadastrar(CategoriaViewModel categoria)
        {
            Categoria categoria1 = new Categoria()
            {
                Codigo = categoria.Codigo,
                Descricao = categoria.Descricao
            };

            _servicoCategoria.Cadastrar(categoria1);

        }

        public CategoriaViewModel CarregarRegistro(int codigoCategoria)
        {
        

            var registro = _servicoCategoria.CarregarRegistro(codigoCategoria);

            CategoriaViewModel categoria = new CategoriaViewModel(); 
            if (categoria != null)
            {
                categoria.Codigo = registro.Codigo;
                categoria.Descricao = registro.Descricao;
            }

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
