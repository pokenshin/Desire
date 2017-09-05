using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    public class GeradorCarisma : IGerador<Carisma>
    {
        public Carisma Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            Carisma carisma = new Carisma()
            {
                Negativo = rng.GerarEntre(0, 100),
                Neutro = rng.GerarEntre(0, 100),
                Positivo = rng.GerarEntre(0, 100)
            };
            return carisma;
        }

        public List<Carisma> GerarLista(int quantidade)
        {
            List<Carisma> resultado = new List<Carisma>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}