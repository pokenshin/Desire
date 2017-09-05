using System;
using System.Collections.Generic;
using System.Text;

namespace Desire.Core.Util.Geradores
{
    class GeradorBoolean: IGerador<bool>
    {
        Random rnd = new Random();

        public bool GeraComChance(int chanceTrue)
        {
            int resultado = rnd.Next(1, 101);

            if (resultado < chanceTrue)
                return true;
            else
                return false;
        }

        public bool Gerar()
        {
            int resultado = rnd.Next(0, 2);

            return (resultado == 1);
        }

        public List<bool> GerarLista(int quantidade)
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
