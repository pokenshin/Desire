using System.Collections.Generic;

namespace Desire.Core.Itens
{
    public class Municao : Item
    {
        public ValorMag DanoBonus { get; set; }
        public ValorMag PenetracaoBonus { get; set; }
        public ValorMag ImpactoBonus { get; set; }
        public ValorMag CorteBonus { get; set; }
    }
}