using System.ComponentModel.DataAnnotations;
using SistemVenda.Dominio.Entidade;

namespace SistemVenda.Models
{
    public class Usuario : EntityBase
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}



 //Dominio.Entidade


