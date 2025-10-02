using System.ComponentModel.DataAnnotations;

namespace SistemVenda.Dominio.Entidade
{
    public class EntityBase
    {
        [Key]
        public int? Codigo { get; set; } 
    }
}