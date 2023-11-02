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
        //ICategoryRepository Category { get; }
        //ICompanyRepository Company { get; }
        //IProductRepository Product { get; }
        //IShoppingCartRepository ShoppingCart { get; }
        //IApplicationUserRepository ApplicationUser { get; }
        //IOrderDetailRepository OrderDetail { get; }
        //IOrderHeaderRepository OrderHeader { get; }
        //IProductImageRepository ProductImage { get; }
        void Save();
    }
}
