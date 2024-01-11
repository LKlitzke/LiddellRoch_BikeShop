using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Models
{
    public class Categoria : BaseModel
    {
        [Required(ErrorMessage = "O campo é de preenchimento obrigatório")]
        [MaxLength(30)]
        [DisplayName("Nome da Categoria")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo é de preenchimento obrigatório")]
        [DisplayName("Ordem de Exibição")]
        [Range(1, 100, ErrorMessage = "O valor deve estar entre 1 a 100")]
        public int OrdemExibicao {  get; set; }
    }
}
