using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    public class GeradorDestino : IGerador<Destino>
    {
        public Destino Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            Destino destino = new Destino()
            {
                Acaso = rng.GerarEntre(0, 100, rnd),
                Azar = rng.GerarEntre(0, 100, rnd),
                Desgraca = rng.GerarEntre(0, 100, rnd),
                Milagre = rng.GerarEntre(0, 100, rnd),
                Sorte = rng.GerarEntre(0, 100, rnd)
            };
            return destino;
        }

        public List<Destino> GerarLista(int quantidade, Random rnd)
        {
            List<Destino> resultado = new List<Destino>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}