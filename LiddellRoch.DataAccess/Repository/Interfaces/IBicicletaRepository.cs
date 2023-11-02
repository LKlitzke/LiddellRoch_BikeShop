using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository.Interfaces
{
    public interface IBicicletaRepository : IRepository<Bicicleta>
    {
        void Update(Bicicleta bicicleta);
    }
}