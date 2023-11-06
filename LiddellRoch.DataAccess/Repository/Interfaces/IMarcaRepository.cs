using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository.Interfaces
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        void Update(Marca marca);
    }
}