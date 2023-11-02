using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository.Interfaces
{
    public interface IImagemProdutoRepository : IRepository<ImagemProduto>
    {
        void Update(ImagemProduto imagemProduto);
    }
}