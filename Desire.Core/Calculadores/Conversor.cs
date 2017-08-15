using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Numerics;

namespace Desire.Core.Calculadores
{
    public class Conversor
    {
        public string ValorMagParaString(int valor, int magnitude)
        {
            string resultado = Convert.ToString(valor);

            for (int i = 0; i < magnitude-2; i++)
            {
                resultado = resultado + "0";
            }
   
            return resultado;
        }

        public ValorMag StringParaValorMag(string numero)
        {
            int magnitude = Convert.ToInt32(numero.Length);
            int valor = 0;
            if (magnitude > 1)
                valor = Convert.ToInt32(numero.Substring(0, 2));
            else
                valor = Convert.ToInt32(numero + "0");

            ValorMag resultado = new ValorMag(valor, magnitude);

            return resultado;
        }
    }
}
