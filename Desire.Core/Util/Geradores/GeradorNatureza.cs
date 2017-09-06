using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    public class GeradorNatureza : IGerador<Natureza>
    {
        public Natureza Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();

            Natureza resultado = new Natureza()
            {
                Apresentacao = rng.GerarEntre(1, 26, rnd),
                Concepcao = rng.GerarEntre(1, 26, rnd),
                Honra = rng.GerarEntre(1, 26, rnd),
                Moral = rng.GerarEntre(1, 26, rnd),
                Percepcao = rng.GerarEntre(1, 26, rnd),
                Personalidade = rng.GerarEntre(1, 26, rnd)
            };

            return resultado;
        }

        public List<Natureza> GerarLista(int quantidade, Random rnd)
        {
            List<Natureza> resultado = new List<Natureza>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}