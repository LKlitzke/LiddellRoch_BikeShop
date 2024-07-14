using LiddellRoch.DataAccess.Data;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        private readonly ApplicationDbContext _db;
        public EmpresaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Empresa empresa)
        {
            _db.Empresas.Update(empresa);
        }
    }
}