using System.ComponentModel.DataAnnotations;

namespace SistemVenda.Dominio.Entidade
{
    public class Cliente : EntityBase 
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CNPJ_CPF { get; set; }
        public string Celular { get; set; }
        public ICollection<Venda> Compras { get; set; }
    }
}