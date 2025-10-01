using System.ComponentModel.DataAnnotations;

namespace SistemVenda.Dominio.Entidade
{
    public class Categoria 
    {        
        [Key]
        public int? Codigo { get; set; }
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}