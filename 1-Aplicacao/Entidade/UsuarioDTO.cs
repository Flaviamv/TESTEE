using System.ComponentModel.DataAnnotations;

namespace SistemVenda.Entidade
{
    public class UsuarioDTO
    {
        [Key]
        public int? Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}