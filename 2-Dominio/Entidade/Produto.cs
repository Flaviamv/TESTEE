
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemVenda.Dominio.Entidade
{
    public class Produto : EntityBase
   {
        public int? Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public float Quantidade { get; set; }
        
        [ForeignKey("Categoria")]
        public int CodigoCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public ICollection<VendaProduto> Vendas { get; set; }
    }
}