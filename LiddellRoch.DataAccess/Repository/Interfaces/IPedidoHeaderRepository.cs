using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository.Interfaces
{
    public interface IPedidoHeaderRepository : IRepository<PedidoHeader>
    {
        void Update(PedidoHeader obj);
        void UpdateStatus(int id, string statusPedido, string? statusPagamento = null);
        void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);
    }
}