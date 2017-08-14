using Desire.Core.Calculos;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Desire.Core
{
    public class ValorMag
    {
        public int Valor { get; set; }
        public int Magnitude { get; set; }
        public string ValorReal { get; set; }

        public ValorMag()
        {
            this.Valor = 0;
            this.Magnitude = 1;
            this.ValorReal = "0";
        }

        public ValorMag(int valor, int magnitude)
        {
            Conversor conversor = new Conversor();
            this.Valor = valor;
            this.Magnitude = magnitude;
            this.ValorReal = conversor.ValorMagParaString(valor, magnitude);
        }

        public ValorMag(string valorReal)
        {
            Conversor conversor = new Conversor();
            ValorMag valor = conversor.StringParaValorMag(valorReal);
            this.ValorReal = valorReal;
            this.Valor = valor.Valor;
            this.Magnitude = valor.Magnitude; 
        }
    }
}
