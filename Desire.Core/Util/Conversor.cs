using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Numerics;

namespace Desire.Core.Util
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
            int magnitude = 0;
            int valor = 0;
            ValorMag resultado = new ValorMag();

            //Se for numero decimal
            if ((numero.Contains(",") || numero.Contains(".")))
            {
                //Se o numero decimal for menor que 10
                if (Convert.ToDecimal(numero) < 10)
                {
                    //Se o numero decimal for maior que 1
                    if (Convert.ToDecimal(numero) > 1)
                    {
                        magnitude = 1;
                        numero = Convert.ToString(numero[0]) + Convert.ToString(numero[2]);
                        valor = Convert.ToInt32(numero);
                        resultado = new ValorMag(valor, magnitude);

                        return resultado;
                    }
                    //Se o numero decimal for menor que 1
                    else
                    {
                        magnitude = 0;

                        if (numero.Contains(","))
                            numero = numero.Split(',')[1];
                        else
                            numero = numero.Split('.')[1];

                        while (numero[0] == '0')
                        {
                            magnitude = magnitude - 1;
                            numero = numero.Remove(0, 1);
                        }

                        if (numero.Length > 3)
                            numero = numero.Remove(2, numero.Length - 2);

                        valor = Convert.ToInt32(numero);

                        if (valor < 10)
                            valor = valor * 10;
                        resultado = new ValorMag(valor, magnitude);

                        return resultado;
                    }
                }
                //Se o numero decimal for maior que 10, descarta quebrados
                else
                {
                    if (numero.Contains(","))
                        numero = numero.Split(',')[0];
                    else
                        numero = numero.Split('.')[0];
                }
            }
            //Se for numero inteiro ou decimal maior que 10
            magnitude = Convert.ToInt32(numero.Length);
            if (magnitude > 1)
                valor = Convert.ToInt32(numero.Substring(0, 2));
            else
                valor = Convert.ToInt32(numero + "0");
            
            resultado = new ValorMag(valor, magnitude);

            return resultado;
        }
    }
}
