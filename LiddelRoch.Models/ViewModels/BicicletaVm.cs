using LiddellRoch.Utility;
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
        [ValidateNever]
        public IEnumerable<SelectListItem> MarcaList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CoresListEnum { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TamanhosListEnum { get; set; }

        [ValidateNever]
        public List<string> TamanhosListSplit { get; set; }
        [ValidateNever]
        public List<string> CoresListSplit { get; set; }
    }
}
