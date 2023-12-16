using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

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
        public IEnumerable<SelectListItem> ComponentesList { get; set; }

        [ValidateNever]
        [Required(ErrorMessage = "Selecione um ou mais tamanhos")]
        public List<string> TamanhosListSplit { get; set; }
        [ValidateNever]
        [Required(ErrorMessage = "Selecione uma ou mais cores")]
        public List<string> CoresListSplit { get; set; }
    }
}
