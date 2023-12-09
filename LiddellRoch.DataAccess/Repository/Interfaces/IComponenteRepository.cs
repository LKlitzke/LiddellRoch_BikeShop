using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository.Interfaces
{
    public interface IComponenteRepository : IRepository<Componente>
    {
        void Update(Componente componente);
    }
}