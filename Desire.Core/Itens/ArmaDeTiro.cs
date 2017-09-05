using System;
using System.Collections.Generic;
using System.Text;

namespace Desire.Core.Itens
{
    public class ArmaDeTiro : Arma
    {
        public int TirosPorCarga { get; set; }
        public int TirosPorAcao { get; set; }
        public ValorMag DistanciaMin { get; set; }
        public ValorMag DistanciaMax { get; set; }
        public string[] Operacoes { get; set; }
        public Municao TipoCarga { get; set; }
        public string ModificadorDano { get; set; }
    }
}
