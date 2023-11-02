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
        [Required]
        public string Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Telefone { get; set; }
    }
}
