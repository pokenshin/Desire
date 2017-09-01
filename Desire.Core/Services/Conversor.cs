using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Numerics;

namespace Desire.Core.Services
{
    public class Conversor
    {
        public string ValorMagParaString(int valor, int magnitude)
        {
            string resultado = Convert.ToString(valor);

            if (valor < 10)
                magnitude = magnitude - 1;
            if (magnitude > 0)
            { 
                for (int i = 0; i < magnitude-2; i++)
                {
                    resultado = resultado + "0";
                }
            }
            else
            {
                resultado = "0," + resultado;
                for (int i = 0; i > magnitude-2; i--)
                {
                    resultado = "0" + resultado;
                }
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
