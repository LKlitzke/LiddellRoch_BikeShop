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
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        [Range(1, 1000000, ErrorMessage = "Selecione um preço entre 1 a 1000000")]
        [RegularExpression(@"^\d+(\,\d{1,2})?$", ErrorMessage = "Apenas duas casas decimais")]
        public decimal Preco { get; set; }

        [Required]
        [Range(1.00, 50.00, ErrorMessage = "Selecione um peso entre 1.00 a 50.00")]
        [RegularExpression(@"^\d+(\,\d{1,2})?$", ErrorMessage = "Apenas duas casas decimais")]
        public double Peso { get; set; }

        [ValidateNever]
        public string Cores { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Range(0,50, ErrorMessage = "Selecione um valor entre 0 a 50")]
        public int DescontoPromocao { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Range(1,100, ErrorMessage = "Selecione um estoque entre 1 a 100")]
        public int Estoque { get; set; }

        [ValidateNever]
        public string Tamanhos { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        [ValidateNever]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        [ValidateNever]
        public Marca Marca { get; set; }

        [ValidateNever]
        public List<ImagemProduto> ImagensProduto { get; set; }

        [ValidateNever]
        public List<Componente> Componentes { get; set; }

        [ValidateNever]
        public List<Avaliacao> Avaliacoes { get; set; }

        [ValidateNever]
        public decimal ValorComDesconto => Preco - (Preco * DescontoPromocao / 100.0m);
    }
}
