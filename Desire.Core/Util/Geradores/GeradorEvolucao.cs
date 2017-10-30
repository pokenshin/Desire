using System;
using System.Collections.Generic;
using Desire.Core.Identidade;
using System.Text;

namespace Desire.Core.Util.Geradores
{
    class GeradorEvolucao : IGerador<Evolucao>
    {
        public Evolucao Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorBoolean rbg = new GeradorBoolean();

            return new Evolucao(rng.GerarEntre(1, 17, rnd), 16, rbg.GeraComChance(10, rnd));
        }

        public List<Evolucao> GerarLista(int quantidade, Random rnd)
        {
            List<Evolucao> resultado = new List<Evolucao>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}
