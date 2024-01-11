using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LiddellRoch.Models.ViewModels
{
    public class ListaBikesVm
    {
        public IEnumerable<Bicicleta> BicicletasList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoriasList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> MarcasList { get; set; }
    }
}
