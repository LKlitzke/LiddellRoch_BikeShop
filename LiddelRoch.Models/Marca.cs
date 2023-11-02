using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Models
{
    public class Marca : BaseModel
    {
        public string Nome { get; set; }
        public string PaisOrigem { get; set; }
        public string IconUrl { get; set; }
        public string SiteOficial { get; set; }
    }
}
