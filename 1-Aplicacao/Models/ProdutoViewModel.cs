using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemVenda.Models
{
    public class ProdutoViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Informe a descrição do Produto!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a Quantidade em Estoque do Produto!")]
        public double Quantidade { get; set; }

        [Required(ErrorMessage = "Informe o Valor unitario do Produto!")]
        [Range(0.1, Double.PositiveInfinity)]
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "Informe a Categoria do Produto!")]
        public int? CodigoCategoria { get; set; } 
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<SelectListItem>? ListaCategorias { get; set; }//Classe que ajuda a renderizar na view
    }
}