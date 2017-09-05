using System;
using System.Collections.Generic;
using System.Text;

namespace Desire.Core.Itens
{
    public class Vestivel : Equipamento
    {
        public ValorMag ResCorte { get; set; }
        public ValorMag ResPenetracao { get; set; }
        public ValorMag ResImpacto { get; set; }
        public ValorMag ResDegeneracao { get; set; }
    }
}
