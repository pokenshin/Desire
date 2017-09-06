using System;
using System.Collections.Generic;
using System.Text;

namespace Desire.Core.Util.Geradores
{
    public class GeradorBoolean: IGerador<bool>
    {
        public bool GeraComChance(int chanceTrue, Random rnd)
        {
            int resultado = rnd.Next(1, 101);

            if (resultado < chanceTrue)
                return true;
            else
                return false;
        }

        public bool Gerar(Random rnd)
        {
            int resultado = rnd.Next(0, 2);

            return (resultado == 1);
        }

        public List<bool> GerarLista(int quantidade, Random rnd)
        {
            List <bool> resultado = new List<bool>();

            for (int i = 0; i < quantidade-1; i++)
            {
                int item = rnd.Next(0, 2);

                resultado.Add((item == 1));
            }
            return resultado;
        }
    }
}
