using System;
using System.Collections.Generic;
using System.Text;

namespace Desire.Core.Itens
{
    public class Equipamento : Item
    {
        public string Slot { get; set; }
        public ValorMag ResCorte { get; set; }
        public ValorMag ResPenetracao { get; set; }
        public ValorMag ResImpacto { get; set; }
        public ValorMag ResDegeneracao { get; set; }
        public int SlotsOcupados { get; set; }
    }
}
