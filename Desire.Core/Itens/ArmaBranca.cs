using System;
using System.Collections.Generic;
using System.Text;

namespace Desire.Core.Itens
{
    public class ArmaBranca : Arma
    {
        public string AtributoBonus { get; set; }
        public string ModificadorDano { get; set; }
        public int MultiplicadorCritico { get; set; }
    }
}
