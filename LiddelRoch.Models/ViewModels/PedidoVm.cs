using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Models.ViewModels
{
    public class PedidoVm
    {
        public PedidoHeader PedidoHeader { get; set; }
        public IEnumerable<PedidoDetalhes> PedidoDetalhe { get; set; }
    }
}
