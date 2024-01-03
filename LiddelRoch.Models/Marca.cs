using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Models
{
    public class Marca : BaseModel
    {
        [Required(ErrorMessage = "O campo é de preenchimento obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo é de preenchimento obrigatório.")]
        public string PaisOrigem { get; set; }
        [Required(ErrorMessage = "O campo é de preenchimento obrigatório.")]
        public string IconUrl { get; set; }
        [Required(ErrorMessage = "O campo é de preenchimento obrigatório.")]
        public string SiteOficial { get; set; }
    }
}
