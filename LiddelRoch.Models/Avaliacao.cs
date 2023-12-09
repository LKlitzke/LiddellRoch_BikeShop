using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiddellRoch.Models
{
    public class Avaliacao : BaseModel
    {
        public int BicicletaId { get; set; }
        [ForeignKey("BicicletaId")]
        public Bicicleta Bicicleta { get; set; }

        public int PedidoHeaderId { get; set; }
        [ForeignKey("PedidoHeaderId")]
        public PedidoHeader PedidoHeader { get; set; }

        [Required]
        public DateTime DataAvaliacao { get; set; }

        [Required]
        public int AvaliacaoCompra { get; set; }

        public string ComentarioCompra { get; set; }
    }
}