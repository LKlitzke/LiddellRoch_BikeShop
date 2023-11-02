using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository.Interfaces
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        void Update(Empresa empresa);
    }
}