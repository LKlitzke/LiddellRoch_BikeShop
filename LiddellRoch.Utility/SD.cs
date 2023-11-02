using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Utility
{
    // Static Details
    public static class SD
    {
        // Roles
        public const string Role_Cliente = "Cliente";
        public const string Role_Empresa = "Empresa";
        public const string Role_Administrador = "Administrador";
        public const string Role_Empregado = "Empregado";

        // Claims
        public static List<Claim> ClaimList = new List<Claim>()
        {
            new Claim("Criar","Criar"),
            new Claim("Editar","Editar"),
            new Claim("Excluir","Excluir")
        };

        // Status de pedidos
        public const string StatusPending = "Pendente";
        public const string StatusApproved = "Aprovado";
        public const string StatusInProcess = "Processando";
        public const string StatusShipped = "Enviado";
        public const string StatusCancelled = "Cancelado";
        public const string StatusRefunded = "Reembolsado";

        // Status de pagamento
        public const string PaymentStatusPending = "Pendente";
        public const string PaymentStatusApproved = "Aprovado";
        public const string PaymentStatusDelayedPayment = "AprovadoParaPagamentoAdiado";
        public const string PaymentStatusRejected = "Rejeitado";

        public const string SessionCart = "SessionShoppingCart";
    }
}
