using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    internal class GeradorNatureza : IGerador<Natureza>
    {
        public Natureza Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();

            Natureza resultado = new Natureza()
            {
                Apresentacao = rng.GerarEntre(1, 26),
                Concepcao = rng.GerarEntre(1, 26),
                Honra = rng.GerarEntre(1, 26),
                Moral = rng.GerarEntre(1, 26),
                Percepcao = rng.GerarEntre(1, 26),
                Personalidade = rng.GerarEntre(1, 26)
            };

            return resultado;
        }

        public List<Natureza> GerarLista(int quantidade)
        {
            List<Natureza> resultado = new List<Natureza>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}