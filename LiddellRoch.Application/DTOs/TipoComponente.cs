using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Application.DTOs
{
    public class TipoComponente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }
    }

    public static class Componentes
    {
        public static List<TipoComponente> GetAll()
        {
            return new List<TipoComponente>
            {
                new TipoComponente() { Id = 1, Nome = "Quadro", Icone = "quadro.png" },
                new TipoComponente() { Id = 2, Nome = "Suspensão", Icone = "suspensao.png" },
                new TipoComponente() { Id = 3, Nome = "Alavanca de Câmbio", Icone = "alavanca.png" },
                new TipoComponente() { Id = 4, Nome = "Número de Marchas", Icone = "num_marchas.png" },
                new TipoComponente() { Id = 5, Nome = "Câmbio Dianteiro", Icone = "alavanca_2.png" },
                new TipoComponente() { Id = 6, Nome = "Câmbio Traseiros", Icone = "cambio_tras.png" },
                new TipoComponente() { Id = 7, Nome = "Cassete", Icone = "cassette.png" },
                new TipoComponente() { Id = 8, Nome = "Movimento Central", Icone = "mov_central.png" },
                new TipoComponente() { Id = 9, Nome = "Pedivela", Icone = "pedivela.png" },
                new TipoComponente() { Id = 10, Nome = "Corrente", Icone = "corrente.png" },
                new TipoComponente() { Id = 11, Nome = "Guidão", Icone = "guidao.png" },
                new TipoComponente() { Id = 12, Nome = "Suporte do Guidão", Icone = "suporte_guidao.png" },
                new TipoComponente() { Id = 13, Nome = "Caixa de Direção", Icone = "caixa.png" },
                new TipoComponente() { Id = 14, Nome = "Conjunto de Freios", Icone = "conjunto_freio.png" },
                new TipoComponente() { Id = 15, Nome = "Pedal", Icone = "pedal.png" },
                new TipoComponente() { Id = 16, Nome = "Selim", Icone = "selim.png" },
                new TipoComponente() { Id = 17, Nome = "Canote", Icone = "canote_selim.png" },
                new TipoComponente() { Id = 18, Nome = "Cubo", Icone = "cubo.png" },
                new TipoComponente() { Id = 19, Nome = "Aros", Icone = "aros.png" },
                new TipoComponente() { Id = 20, Nome = "Raios", Icone = "raio.png" },
                new TipoComponente() { Id = 21, Nome = "Pneus", Icone = "pneu.png" }
            };
        }
    }
}
