using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Models
{
    public class Empresa : BaseModel
    {
        [Required(ErrorMessage = "O campo é de preenchimento obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo é de preenchimento obrigatório.")]
        [MinLength(15, ErrorMessage = "Insira um endereço com ao menos 15 dígitos")]
        public string? Endereco { get; set; }
        [Required(ErrorMessage = "O campo é de preenchimento obrigatório.")]
        public string? Cidade { get; set; }
        [Required(ErrorMessage = "O campo é de preenchimento obrigatório.")]
        public string? Estado { get; set; }
        [Required(ErrorMessage = "O campo é de preenchimento obrigatório.")]
        [MinLength(8, ErrorMessage = "Insira um CEP válido")]
        public string? CodigoPostal { get; set; }
        [Required(ErrorMessage = "O campo é de preenchimento obrigatório.")]
        [MinLength(11, ErrorMessage = "O campo deve possuir 11 dígitos")]
        public string? Telefone { get; set; }
    }
}
