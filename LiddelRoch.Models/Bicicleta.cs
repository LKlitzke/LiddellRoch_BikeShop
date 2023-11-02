using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiddellRoch.Utility;
using System.Text.RegularExpressions;

namespace LiddellRoch.Models
{
    public class Bicicleta : BaseModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\d+(\,\d{1,2})?$", ErrorMessage = "Apenas duas casas decimais")]
        public decimal Preco { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\,\d{1,2})?$", ErrorMessage = "Apenas duas casas decimais")]
        public double Peso { get; set; }

        [Required]
        public string Cores { get; set; }

        [Required]
        public int Estoque { get; set; }

        [Required]
        public string Tamanhos { get; set; }

        // Adicionar componentes individuais?

        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        [ValidateNever]
        public Categoria Categoria { get; set; }

        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        [ValidateNever]
        public Marca Marca { get; set; }

        [ValidateNever]
        public List<ImagemProduto> ImagensProduto { get; set; }
    }
}
