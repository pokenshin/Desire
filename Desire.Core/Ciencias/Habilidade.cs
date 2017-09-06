using System.Collections.Generic;
using Desire.Core.Efeitos;
using Desire.Core.Energias;

namespace Desire.Core.Ciencias
{
    public class Habilidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Magnitude { get; set; }
        public string Caracteristicas { get; set; }
        public TipoHabilidade Tipo { get; set; }
        public Energia Energia { get; set; }
        public Pericia PericiaAssociada { get; set; }
        public AreaCientifica AreaCientifica { get; set; }
        public List<IEfeito> Efeitos { get; set; }
    }
}