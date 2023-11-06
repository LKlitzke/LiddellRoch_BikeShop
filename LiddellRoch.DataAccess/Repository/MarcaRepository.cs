using LiddellRoch.DataAccess.Data;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository
{
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        private ApplicationDbContext _db;
        public MarcaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Marca marca)
        {
            _db.Marcas.Update(marca);
        }
    }
}