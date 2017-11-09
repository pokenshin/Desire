using System;
using System.Collections.Generic;
using Desire.Core;
using System.Text;

namespace Desire.Util.Calculadores
{
    public class CalculadorNumero
    {
        public decimal CalculaPA(decimal a1, int n, int r)
        {
            decimal resultado = 0;

            resultado = a1 + ((n - 1) * r);

            return resultado;
        }

        public ValorMag MultiplicaValorMag(ValorMag valorMag1, ValorMag valorMag2)
        {
            if (valorMag1.ToString() == "1m2" || valorMag1.ToString() == "10m1")
                return valorMag2;
            else if (valorMag2.ToString() == "1m2" || valorMag2.ToString() == "10m1")
                return valorMag1;
            else if (valorMag1.Valor == 0 || valorMag2.Valor == 0)
                return new ValorMag(0, 1);
            else
            {
                int magFinal = (valorMag1.Magnitude + valorMag2.Magnitude) - 2;

                int valorFinal = (valorMag1.Valor * valorMag2.Valor);
                while (valorFinal > 99)
                {
                    valorFinal = valorFinal / 10;
                    magFinal = magFinal + 1;
                }

                return new ValorMag(valorFinal, magFinal);
            }
        }

        public ValorMag DivideValorMag(ValorMag valorMag1, ValorMag valorMag2)
        {
            if (valorMag1.ValorReal == "0")
                return new ValorMag("0");
            else if (valorMag2.ValorReal == "0")
                return new ValorMag("0");
            else if (valorMag2.ValorReal == "1")
                return valorMag1;
            else
            {
                int magFinal = ((valorMag1.Magnitude - 2) - (valorMag2.Magnitude - 2)) + 2;

                double valorFinal = ((double)valorMag1.Valor / (double)valorMag2.Valor);

                while (valorFinal < 10)
                {
                    valorFinal = valorFinal * 10;
                    magFinal = magFinal - 1;
                }

                return new ValorMag((int)Math.Floor(valorFinal), magFinal);
            }
        }

        public ValorMag DivideValorMag(ValorMag valorMag1, int divisor)
        {
            if (divisor == 0)
                return new ValorMag("0");
            if (divisor == 1)
                return valorMag1;
            else
                return DivideValorMag(valorMag1, new ValorMag(Convert.ToString(divisor)));
        }

        public ValorMag MultiplicaValorMag(ValorMag valorMag1, int multiplicador)
        {
            if (multiplicador == 1)
                return valorMag1;
            else if (valorMag1 == new ValorMag() || multiplicador == 0)
                return new ValorMag(0, 1);
            else
                return MultiplicaValorMag(valorMag1, new ValorMag(Convert.ToString(multiplicador)));
        }

        public ValorMag MultiplicaValorMag(ValorMag numero, double multiplicador)
        {
            if (multiplicador == 1)
                return numero;
            else if (numero == new ValorMag() || multiplicador == 0)
                return new ValorMag(0, 1);
            else
                return MultiplicaValorMag(numero, new ValorMag(Convert.ToString(multiplicador)));
            //double valorFinal = numero.Valor * multiplicador;
            //int magFinal = numero.Magnitude;

            //if (valorFinal < 10)
            //{ 
            //    magFinal = magFinal - 1;
            //    valorFinal = valorFinal * 10;
            //}
            //else if (valorFinal > 99)
            //{
            //    while (valorFinal > 99)
            //    { 
            //        valorFinal = valorFinal / 100;
            //        magFinal = magFinal + 1;
            //    }
            //}

            //ValorMag resultado = new ValorMag((int)Math.Floor(valorFinal), magFinal);
            //return resultado;
        }
        
        //Retorna a porcentagem de um determinado valor arredondado para baixo
        public long CalculaPorcentagem(int porcentagem, long valor)
        {
            double pct = (double)porcentagem / 100;
            double resultado = (double)valor * pct;
            return (int)Math.Floor(resultado);
        }

        public double CalculaPorcentagemDeTotal(long valor, long total)
        {
            return valor / total;
        }

        public ValorMag SubtraiValorMag(ValorMag valorMag1, ValorMag valorMag2)
        {
            if (valorMag1.ToString() == valorMag2.ToString())
                return new ValorMag();

            int valorFinal = 0;
            int magnitudeFinal = 0;
            int valor1 = valorMag1.Valor;
            int valor2 = valorMag2.Valor;
            int mag1 = valorMag1.Magnitude;
            int mag2 = valorMag2.Magnitude;

            if (mag1 == mag2)
            {
                magnitudeFinal = mag1;
                valorFinal = valor1 - valor2;

                if (valorFinal < 0)
                {
                    valorFinal = valorFinal * 10;
                    magnitudeFinal = magnitudeFinal - 1;
                }
            }
            else if (mag1 - mag2 == 1 || mag1 - mag2 == -1)
            {
                magnitudeFinal = Math.Max(mag1, mag2);

                if (magnitudeFinal == mag1)
                    valorFinal = valor1 - (valor2 / 10);
                else
                    valorFinal = valor2 - (valor1 / 10);
            }
            else
            {
                magnitudeFinal = Math.Max(mag1, mag2);
                if (magnitudeFinal == mag1)
                    valorFinal = valor1;
                else
                    valorFinal = valor2;
            }

            ValorMag resultado = new ValorMag(valorFinal, magnitudeFinal);

            return resultado;
        }

        public ValorMag SomaValorMag(ValorMag valorMag1, ValorMag valorMag2)
        {
            int valorFinal = 0;
            int magnitudeFinal = 0;
            int valor1 = valorMag1.Valor;
            int valor2 = valorMag2.Valor;
            int mag1 = valorMag1.Magnitude;
            int mag2 = valorMag2.Magnitude;

            if (mag1 == mag2)
            {
                magnitudeFinal = mag1;
                valorFinal = valor1 + valor2;

                if (valorFinal > 99)
                {
                    valorFinal = valorFinal / 10;
                    magnitudeFinal = magnitudeFinal + 1;
                }
            }
            else if (mag1 - mag2 == 1 || mag1 - mag2 == -1)
            {
                magnitudeFinal = Math.Max(mag1, mag2);

                if (magnitudeFinal == mag1)
                    valorFinal = valor1 + (valor2 / 10);
                else
                    valorFinal = valor2 + (valor1 / 10);
            }
            else
            {
                magnitudeFinal = Math.Max(mag1, mag2);
                if (magnitudeFinal == mag1)
                    valorFinal = valor1;
                else
                    valorFinal = valor2;
            }

            ValorMag resultado = new ValorMag(valorFinal, magnitudeFinal);
            return resultado;
        }

        public ValorMag RetornaMenorValorMag(ValorMag num1, ValorMag num2)
        {
            if (num1.Magnitude != num2.Magnitude)
            {
                if (num1.Magnitude > num2.Magnitude)
                    return num2;
                else
                    return num1;
            }
            else
            {
                if (num1.Valor > num2.Valor)
                    return num2;
                else
                    return num1;
            }
        }

        public ValorMag RetornaMaiorValorMag(List<ValorMag> lista)
        {
            if (lista.Count > 0)
            {
                ValorMag resultado = lista[0];
                foreach (ValorMag item in lista)
                {
                    resultado = RetornaMaiorValorMag(resultado, item);
                }
                return resultado;
            }
            else
                return new ValorMag();
        }

        public ValorMag RetornaMaiorValorMag(ValorMag num1, ValorMag num2)
        {
            if (num1.Magnitude != num2.Magnitude)
            {
                if (num1.Magnitude > num2.Magnitude)
                    return num1;
                else
                    return num2;
            }
            else
            {
                if (num1.Valor > num2.Valor)
                    return num1;
                else
                    return num2;
            }
        }

        public ValorMag RetornaMenorValorMag(List<ValorMag> lista)
        {
            if (lista.Count > 0)
            {
                ValorMag resultado = lista[0];
                foreach (ValorMag item in lista)
                {
                    resultado = RetornaMenorValorMag(resultado, item);
                }
                return resultado;
            }
            else
                return new ValorMag();
        }
    }
}
