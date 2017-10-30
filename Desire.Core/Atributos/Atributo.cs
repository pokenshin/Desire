using System;
using System.Collections.Generic;
using System.Text;
using Desire.Core.Identidade;

namespace Desire.Core
{
    public abstract class Atributo
    {
        public char Classe { get; set; }
        public int Nivel { get; set; }
        public int Pontos { get; set; }
        public ValorMag Porcentagem { get; set; }
    }
}
