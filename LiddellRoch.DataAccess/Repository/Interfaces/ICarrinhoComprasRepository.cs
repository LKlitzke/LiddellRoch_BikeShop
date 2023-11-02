using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository.Interfaces
{
    public interface ICarrinhoComprasRepository : IRepository<CarrinhoCompras>
    {
        void Update(CarrinhoCompras carrinhoCompras);
    }
}