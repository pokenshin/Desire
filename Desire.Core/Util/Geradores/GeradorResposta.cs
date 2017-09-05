using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    public class GeradorResposta : IGerador<Resposta>
    {
        public Resposta Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            Resposta resposta = new Resposta()
            {
                Bravura = rng.GerarEntre(1, 1000),
                Coragem = rng.GerarEntre(1, 1000),
                Desespero = rng.GerarEntre(1, 1000),
                Heroismo = rng.GerarEntre(1, 1000),
                Indiferenca = rng.GerarEntre(1, 1000),
                Medo = rng.GerarEntre(1, 1000),
                Panico = rng.GerarEntre(1, 1000)
            };

            return resposta;
        }

        public List<Resposta> GerarLista(int quantidade)
        {
            List<Resposta> resultado = new List<Resposta>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}