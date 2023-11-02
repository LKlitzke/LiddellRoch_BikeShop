using LiddellRoch.DataAccess.Data;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository
{
    public class CarrinhoComprasRepository : Repository<CarrinhoCompras>, ICarrinhoComprasRepository
    {
        private ApplicationDbContext _db;
        public CarrinhoComprasRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CarrinhoCompras carrinhoCompras)
        {
            _db.CarrinhoCompras.Update(carrinhoCompras);
        }
    }
}