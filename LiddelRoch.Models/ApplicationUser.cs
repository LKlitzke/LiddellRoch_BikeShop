using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LiddellRoch.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CodigoPostal { get; set; }
        public int? EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        [ValidateNever]
        public Empresa? Empresa { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
