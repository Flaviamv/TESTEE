using System.ComponentModel.DataAnnotations;

namespace SistemVenda.Dominio.Entidade
{
    public class Usuario : EntityBase
    {
        [Key]
        public int? Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}