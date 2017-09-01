using System.Collections.Generic;

namespace Desire.Core.Identidade
{
    public class Habilidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Magnitude { get; set; }
        public string Caracteristicas { get; set; }

        public Energia Energia { get; set; }
        public Pericia PericiaAssociada { get; set; }
        public ValorMag ValorEfeito { get; set; }
        public string Duracao { get; set; }
        public ValorMag ValorDuracao { get; set; }
        public List<Modificador> Modificadores { get; set; }
        public string TipoAlvo { get; set; }
        public Area Area { get; set; }
        public string TipoHabilidade { get; set; }
    }
}