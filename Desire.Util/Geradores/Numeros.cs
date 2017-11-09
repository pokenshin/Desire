using System;
using System.Collections.Generic;
using Desire.Core;

namespace Desire.Util.Geradores
{
    internal interface IGeradorNumero<T>
    {
        ///<summary>
        ///Gera um numero aleatório entre dois valores especificados.
        ///</summary>
        /// <param name="min">Valor Mínimo do número aleatório (inclusivo)</param>
        /// <param name="max">Valor Máximo do número aleatório (inclusivo)</param>
        T GerarEntre(T min, T max, Random rnd);
        ///<summary>
        ///Gera uma lista de numeros no range e na quantidade especificados.
        ///</summary>
        /// <param name="min">Valor Mínimo do número aleatório (inclusivo)</param>
        /// <param name="max">Valor Máximo do número aleatório (inclusivo)</param>
        /// <param name="quantidade">Quantidade máxima de itens na lista</param>
        List<T> GeraListaRange(T min, T max, int quantidade, Random rnd);
    }

    ///<summary>
    ///Classe que possui métodos para gerar números inteiros.
    ///</summary>
    public class GeradorInteiro: IGerador<int>, IGeradorNumero<int>
    {
        public int Gerar(Random rnd)
        {
            return rnd.Next(int.MinValue, int.MaxValue);
        }

        public List<int> GerarLista(int quantidade, Random rnd)
        {
            return GeraListaRange(int.MinValue, int.MaxValue, quantidade, rnd);
        }

        public int GerarEntre(int min, int max, Random rnd)
        {
            return rnd.Next(min, max + 1);
        }

        public List<int> GeraListaRange(int min, int max, int quantidade, Random rnd)
        {
            List<int> resultado = new List<int>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(GerarEntre(min, max, rnd));
            }

            return resultado;
        }

        public int[] GerarInteirosQueSomam(int quantidadeNumeros, int somaTotal, Random rnd)
        {
            int[] resultado = new int[quantidadeNumeros];
            double soma = 0;
            int novaSoma = 0;
            int diferenca = 0;

            for (int i = 0; i < quantidadeNumeros; i++)
            {
                resultado[i] = GerarEntre(1, 100, rnd);
                if (i > 0)
                    soma = soma + resultado[i];
                else
                    soma = resultado[i];
            }

            double k = soma / somaTotal;

            for (int i = 0; i < quantidadeNumeros; i++)
            {
                double numeroNovo = (double)resultado[i] / k;
                novaSoma = novaSoma + Convert.ToInt32(numeroNovo);
                resultado[i] = Convert.ToInt32(numeroNovo);
            }

            if (novaSoma != somaTotal)
            {
                if (novaSoma > somaTotal)
                {
                    diferenca = Convert.ToInt32(novaSoma - somaTotal);
                    resultado[resultado.Length - 1] = resultado[resultado.Length - 1] - diferenca;
                }
                else
                {
                    diferenca = Convert.ToInt32(somaTotal - novaSoma);
                    resultado[resultado.Length - 1] = resultado[resultado.Length - 1] + diferenca;
                }
            }

            return resultado;
        }
    }

    ///<summary>
    ///Classe que possui métodos para gerar ValorMag.
    ///</summary>
    public class GeradorValorMag : IGerador<ValorMag>, IGeradorNumero<ValorMag>
    {
        public List<ValorMag> GeraListaRange(ValorMag min, ValorMag max, int quantidade, Random rnd)
        {
            List<ValorMag> resultado = new List<ValorMag>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(GerarEntre(min, max, rnd));
            }

            return resultado;

        }

        ///<summary>
        ///Gera um ValorMag aleatório entre 10m0 e 99m20
        ///</summary>
        public ValorMag Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            int valor = rng.GerarEntre(10, 99, rnd);
            int mag = rng.GerarEntre(0, 20, rnd);
            return new ValorMag(valor, mag);
        }

        public ValorMag GerarEntre(ValorMag min, ValorMag max, Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            int valor = 1;
            int mag = rng.GerarEntre(min.Magnitude, max.Magnitude, rnd);

            if (mag == min.Magnitude)
            {
                if (mag == max.Magnitude)
                    valor = rng.GerarEntre(min.Valor, max.Valor, rnd);
                else
                    valor = rng.GerarEntre(min.Valor, 99, rnd);
            }
            else if (mag == max.Magnitude)
                valor = rng.GerarEntre(10, max.Valor, rnd);
            else
                valor = rng.GerarEntre(10, 99, rnd);

            ValorMag resultado = new ValorMag(valor, mag);

            return resultado;
        }

        ///<summary>
        ///Gera uma lista de ValorMag aleatórios entre 10m0 e 99m20
        ///</summary>
        ///<param name="quantidade">Quantidade máxima de itens na lista</param>
        public List<ValorMag> GerarLista(int quantidade, Random rnd)
        {
            List<ValorMag> resultado = new List<ValorMag>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }

    ///<summary>
    ///Classe que possui métodos para gerar long.
    ///</summary>
    public class GeradorLong : IGerador<long>, IGeradorNumero<long>
    {
        Random rnd = new Random();

        public List<long> GeraListaRange(long min, long max, int quantidade, Random rnd)
        {
            List<long> resultado = new List<long>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(GerarEntre(min, max, rnd));
            }

            return resultado;
        }

        public long Gerar(Random rnd)
        {
            byte[] buffer = new byte[8];
            rnd.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }

        public long GerarEntre(long min, long max, Random rnd)
        {
            byte[] buf = new byte[8];
            rnd.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }

        public List<long> GerarLista(int quantidade, Random rnd)
        {
            List<long> resultado = new List<long>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}