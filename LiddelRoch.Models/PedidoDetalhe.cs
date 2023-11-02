using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Models
{
    public class PedidoDetalhe : BaseModel
    {
        public int PedidoHeaderId { get; set; }
        [ForeignKey("PedidoHeaderId")]
        [ValidateNever]
        public PedidoHeader PedidoHeader { get; set; }

        [Required]
        public int BicicletaId { get; set; }
        [ForeignKey("BicicletaId")]
        [ValidateNever]
        public Bicicleta Bicicleta { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}
