using LiddellRoch.DataAccess.Data;
using LiddellRoch.DataAccess.Repository.Interfaces;

namespace LiddellRoch.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoriaRepository Categoria { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public ICarrinhoComprasRepository CarrinhoCompras { get; private set; }
        public IMarcaRepository Marca { get; private set; }
        public IEmpresaRepository Empresa { get; private set; }
        public IBicicletaRepository Bicicleta { get; private set; }
        public IPedidoHeaderRepository PedidoHeader { get; private set; }
        public IPedidoDetalheRepository PedidoDetalhes { get; private set; }
        public IImagemProdutoRepository ImagemProduto { get; private set; }
        public IComponenteRepository Componente { get; private set; }
        public IAvaliacaoRepository Avaliacao { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Categoria = new CategoriaRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            CarrinhoCompras = new CarrinhoComprasRepository(_db);
            Empresa = new EmpresaRepository(_db);
            Marca = new MarcaRepository(_db);
            Bicicleta = new BicicletaRepository(_db);
            PedidoHeader = new PedidoHeaderRepository(_db);
            PedidoDetalhes = new PedidoDetalheRepository(_db);
            ImagemProduto = new ImagemProdutoRepository(_db);
            Componente = new ComponenteRepository(_db);
            Avaliacao = new AvaliacaoRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
