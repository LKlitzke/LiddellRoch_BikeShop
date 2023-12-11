using LiddellRoch.DataAccess.Data;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;

namespace LiddellRoch.DataAccess.Repository
{
    public class BicicletaRepository : Repository<Bicicleta>, IBicicletaRepository
    {
        private ApplicationDbContext _db;
        public BicicletaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Bicicleta obj)
        {
            var objFromDb = _db.Bicicletas.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Nome = obj.Nome;
                objFromDb.Descricao = obj.Descricao;
                objFromDb.DescontoPromocao = obj.DescontoPromocao;
                //objFromDb.Especificoes = obj.Especificoes;
                objFromDb.Componentes = obj.Componentes;
                objFromDb.Peso = obj.Peso;
                objFromDb.Cores = obj.Cores;
                objFromDb.CategoriaId = obj.CategoriaId;
                objFromDb.MarcaId = obj.MarcaId;
                objFromDb.ImagensProduto = obj.ImagensProduto;
                objFromDb.Tamanhos = obj.Tamanhos;
                objFromDb.CriadoEm = obj.CriadoEm;
                objFromDb.Preco = obj.Preco;
            }
        }
    }
}