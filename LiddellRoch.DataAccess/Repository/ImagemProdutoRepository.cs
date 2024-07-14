using LiddellRoch.DataAccess.Data;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository
{
    internal class ImagemProdutoRepository : Repository<ImagemProduto>, IImagemProdutoRepository
    {
        private readonly ApplicationDbContext _db;
        public ImagemProdutoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ImagemProduto obj)
        {
            _db.ImagemProdutos.Update(obj);
        }
    }
}