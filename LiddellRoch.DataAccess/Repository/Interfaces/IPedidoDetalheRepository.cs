using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository.Interfaces
{
    public interface IPedidoDetalheRepository : IRepository<PedidoDetalhe>
    {
        void Update(PedidoDetalhe pedidoDetalhes);
    }
}