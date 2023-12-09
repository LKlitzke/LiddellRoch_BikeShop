using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository.Interfaces
{
    public interface IAvaliacaoRepository : IRepository<Avaliacao>
    {
        void Update(Avaliacao avaliacao);
    }
}