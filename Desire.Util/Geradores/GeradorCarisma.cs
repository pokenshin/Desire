using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Util.Geradores
{
    public class GeradorCarisma : IGerador<Carisma>
    {
        public Carisma Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            Carisma carisma = new Carisma()
            {
                Negativo = rng.GerarEntre(0, 100, rnd),
                Neutro = rng.GerarEntre(0, 100, rnd),
                Positivo = rng.GerarEntre(0, 100, rnd)
            };
            return carisma;
        }

        public List<Carisma> GerarLista(int quantidade, Random rnd)
        {
            List<Carisma> resultado = new List<Carisma>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}