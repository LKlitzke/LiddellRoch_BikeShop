using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Models.ViewModels
{
    public class CarrinhoComprasVm
    {
        public IEnumerable<CarrinhoCompras> CarrinhoComprasList { get; set; }
        public PedidoHeader PedidoHeader { get; set; }
    }
}
