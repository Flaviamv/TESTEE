using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using _3_Repositorio.Entidades;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using SistemVenda.Dominio.Entidade;
using SistemVendas.Models;

namespace Repositorio.Entidades
{
    public class RepositorioVendaProduto : DbContext, IRepositorioVendaProdutos
    {
        protected ApplicationDbContext DbSetContext;

        public RepositorioVendaProduto(ApplicationDbContext mContext)
        {
            DbSetContext = mContext;
        }
        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            var lista = DbSetContext.VendaProduto.Include(x => x.Produto).GroupBy(x => x.CodigoProduto).Select(y => new GraficoViewModel
            {
                CodigoProduto = y.First().CodigoProduto,
                Descricao = y.First().Produto.Descricao,
                TotalVendido = y.Sum(z => z.QuantidadeProduto)
            }).ToList();

            return lista;
        }
    }
}