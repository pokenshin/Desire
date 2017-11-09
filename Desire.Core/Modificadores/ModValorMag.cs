using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Desire.Core.Modificadores
{
    public abstract class ModValorMag : Modificador
    {
        public ValorMag Valor { get; set; }
        public abstract char Operador { get; }
        public string Alvo { get; set; }

        public override string ToString()
        {
            return this.Alvo + this.Operador + this.Valor.ToString() + " (" + this.Origem + ")";
        }
    }

    public class ModSomaValorMag : ModValorMag
    {
        public override char Operador => '+';
    }

    public class ModSubtraiValorMag : ModValorMag
    {
        public override char Operador => '-';
    }

    public class ModMultiplicaValorMag : ModValorMag
    {
        public override char Operador => '*';
    }

    public class ModDivideValorMag : ModValorMag
    {
        public override char Operador => '/';
    }
}
