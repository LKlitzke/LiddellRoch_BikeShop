using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.DataAccess.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        // Listar Interfaces de repositorios das entidades 
        ICategoriaRepository Categoria { get; }
        IEmpresaRepository Empresa { get; }
        IMarcaRepository Marca { get; }
        IBicicletaRepository Bicicleta { get; }
        ICarrinhoComprasRepository CarrinhoCompras { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IPedidoDetalheRepository PedidoDetalhes { get; }
        IPedidoHeaderRepository PedidoHeader { get; }
        IImagemProdutoRepository ImagemProduto { get; }
        IComponenteRepository Componente { get; }
        IAvaliacaoRepository Avaliacao { get; }
        void Save();
    }
}
