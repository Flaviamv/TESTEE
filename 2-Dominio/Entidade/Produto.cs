
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemVenda.Dominio.Entidade
{
    public class Produto : EntityBase
   {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public float Quantidade { get; set; }
        
        [ForeignKey("Categoria")]
        public int CodigoCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public ICollection<VendaProduto> Vendas { get; set; }
    }
}