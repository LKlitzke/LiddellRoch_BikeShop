using LiddellRoch.DataAccess.Data;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository
{
    public class ComponenteRepository : Repository<Componente>, IComponenteRepository
    {
        private readonly ApplicationDbContext _db;
        public ComponenteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Componente categoria)
        {
            _db.Componentes.Update(categoria);
        }
    }
}