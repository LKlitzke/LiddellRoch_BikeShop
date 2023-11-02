using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        void Update(Categoria categoria);
    }
}