using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    public class GeradorDestino : IGerador<Destino>
    {
        public Destino Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            Destino destino = new Destino()
            {
                Acaso = rng.GerarEntre(0, 100),
                Azar = rng.GerarEntre(0, 100),
                Desgraca = rng.GerarEntre(0, 100),
                Milagre = rng.GerarEntre(0, 100),
                Sorte = rng.GerarEntre(0, 100)
            };
            return destino;
        }

        public List<Destino> GerarLista(int quantidade)
        {
            List<Destino> resultado = new List<Destino>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}