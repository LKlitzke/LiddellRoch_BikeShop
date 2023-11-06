using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Models
{
    public class CarrinhoCompras : BaseModel
    {
        public int BicicletaId { get; set; }
        [ForeignKey("BicicletaId")]
        [ValidateNever]
        public Bicicleta Bicicleta { get; set; }

        [Range(1, 100, ErrorMessage = "O valor deve estar entre 1 a 100")]
        public int Quantidade { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public decimal Preco { get; set; }
    }
}
