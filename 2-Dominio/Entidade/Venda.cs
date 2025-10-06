using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemVenda.Dominio.Entidade
{
    public class Venda : EntityBase
    {
    
        public DateTime Data { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("Cliente")]
        public int CodigoCliente { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<VendaProduto> Produtos { get; set; }
    }
}