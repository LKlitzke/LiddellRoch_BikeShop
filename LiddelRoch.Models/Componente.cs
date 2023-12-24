using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiddellRoch.Models
{
    public class Componente : BaseModel
    {
        public int TipoComponenteId { get; set; }
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        public string Valor {  get; set; }
        public int BicicletaId { get; set; }
        [ForeignKey("BicicletaId")]
        public Bicicleta Bicicleta { get; set; }
    }
}