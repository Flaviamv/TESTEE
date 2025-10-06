using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemVenda.Dominio.Entidade;

namespace SistemVenda.Entidade
{
    public class Produto
    {
        [Key]
        public int? Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public float Quantidade { get; set; }
        
        [ForeignKey("Categoria")]
        public int CodigoCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public ICollection<VendaProdutoDTO> Vendas { get; set; }
    }
}