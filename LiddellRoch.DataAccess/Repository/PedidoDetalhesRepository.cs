using LiddellRoch.DataAccess.Data;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository
{
    internal class PedidoDetalheRepository : Repository<PedidoDetalhe>, IPedidoDetalheRepository
    {
        private ApplicationDbContext _db;
        public PedidoDetalheRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PedidoDetalhe obj)
        {
            _db.PedidoDetalhes.Update(obj);
        }
    }
}