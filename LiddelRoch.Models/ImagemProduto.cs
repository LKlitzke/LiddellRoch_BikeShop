using System.ComponentModel.DataAnnotations.Schema;

namespace LiddellRoch.Models
{
    public class ImagemProduto : BaseModel
    {
        public string ImagemUrl { get; set; }
        public int BicicletaId { get; set; }
        [ForeignKey("BicicletaId")]
        public Bicicleta Bicicleta { get; set; }
    }
}