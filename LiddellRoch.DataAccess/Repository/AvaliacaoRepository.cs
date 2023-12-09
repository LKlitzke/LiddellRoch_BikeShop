using LiddellRoch.DataAccess.Data;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository
{
    internal class AvaliacaoRepository : Repository<Avaliacao>, IAvaliacaoRepository
    {
        private ApplicationDbContext _db;
        public AvaliacaoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Avaliacao obj)
        {
            _db.Avaliacoes.Update(obj);
        }
    }
}