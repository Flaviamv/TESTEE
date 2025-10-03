using System.ComponentModel.DataAnnotations;
using SistemVenda.Entidade;

namespace SistemVenda.Dominio.Entidade
{
    public class Categoria : EntityBase
    {        
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}