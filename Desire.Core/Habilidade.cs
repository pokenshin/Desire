using System.Collections.Generic;

namespace Desire.Core
{
    public class Habilidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Nivel { get; set; }
        public string Tipo { get; set; }
        public string Caracteristicas { get; set; }
        public Energia TipoEnergia { get; set; }
        public int ValorEnergia { get; set; }
        public Pericia PericiaAssociada { get; set; }
        public int ValorEfeito { get; set; }
        public string Duracao { get; set; }
        public int ValorDuracao { get; set; }
        public List<Modificador> Modificadores { get; set; }
        public string TipoAlvo { get; set; }
        public Area Area { get; set; }


    }
}