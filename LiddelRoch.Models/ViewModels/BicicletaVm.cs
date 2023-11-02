using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Models.ViewModels
{
    public class BicicletaVm
    {
        public Bicicleta Bicicleta { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoriaList { get; set; }
    }
}
