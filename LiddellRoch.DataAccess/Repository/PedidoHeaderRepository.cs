using LiddellRoch.DataAccess.Data;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository
{
    internal class PedidoHeaderRepository : Repository<PedidoHeader>, IPedidoHeaderRepository
    {
        private ApplicationDbContext _db;
        public PedidoHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PedidoHeader obj)
        {
            _db.PedidoHeaders.Update(obj);
        }

        public void UpdateStatus(int id, string statusPedido, string? statusPagamento = null)
        {
            var orderFromDb = _db.PedidoHeaders.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.StatusPedido = statusPedido;
                if (!string.IsNullOrEmpty(statusPagamento))
                {
                    orderFromDb.StatusPagamento = statusPagamento;
                }
            }
        }

        public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
        {
            var orderFromDb = _db.PedidoHeaders.FirstOrDefault(u => u.Id == id);
            if (!string.IsNullOrEmpty(sessionId))
            {
                orderFromDb.SessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                orderFromDb.PaymentIntentId = paymentIntentId;
                orderFromDb.DataPagamento = DateTime.Now.AddHours(-3);
            }
        }
    }
}