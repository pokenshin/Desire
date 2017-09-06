using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    public class GeradorResposta : IGerador<Resposta>
    {
        public Resposta Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            Resposta resposta = new Resposta()
            {
                Bravura = rng.GerarEntre(1, 1000, rnd),
                Coragem = rng.GerarEntre(1, 1000, rnd),
                Desespero = rng.GerarEntre(1, 1000, rnd),
                Heroismo = rng.GerarEntre(1, 1000, rnd),
                Indiferenca = rng.GerarEntre(1, 1000, rnd),
                Medo = rng.GerarEntre(1, 1000, rnd),
                Panico = rng.GerarEntre(1, 1000, rnd)
            };

            return resposta;
        }

        public List<Resposta> GerarLista(int quantidade, Random rnd)
        {
            List<Resposta> resultado = new List<Resposta>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}