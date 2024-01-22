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
    public class PedidoHeader : BaseModel
    {
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataEnvio { get; set; }
        public decimal TotalPedido { get; set; }
        public string? StatusPedido { get; set; }
        public string? StatusPagamento { get; set; }
        public string? NumeroRastreio { get; set; }
        public string? Transportadora { get; set; }

        public DateTime DataPagamento { get; set; }
        public DateTime DataVencimentoPagamento { get; set; }

        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }

		[Required(ErrorMessage = "Preencha este campo obrigatório.")]
		[MinLength(11, ErrorMessage = "O campo deve possuir 11 dígitos")]
		public string Telefone { get; set; }

		[Required(ErrorMessage = "Preencha este campo obrigatório.")]
		[MinLength(10, ErrorMessage = "Insira um endereço com ao menos 10 dígitos")]
		public string Endereco { get; set; }

		[Required(ErrorMessage = "Preencha este campo obrigatório.")]
		public string Cidade { get; set; }

		[Required(ErrorMessage = "Preencha este campo obrigatório.")]
		public string Estado { get; set; }

		[Required(ErrorMessage = "Preencha este campo obrigatório.")]
		[MinLength(8, ErrorMessage = "Insira um CEP válido")]
		public string CodigoPostal { get; set; }

		[Required(ErrorMessage = "Preencha este campo obrigatório.")]
		[MinLength(10, ErrorMessage = "Insira um nome com ao menos 10 dígitos")]
		public string Nome { get; set; }

        public string TotalPedidoStr => TotalPedido.ToString("c");
    }
}
