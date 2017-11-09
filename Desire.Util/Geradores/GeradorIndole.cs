using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Util.Geradores
{
    public class GeradorIndole : IGerador<Indole>
    {
        public Indole Gerar(Random rnd)
        {
            GeradorString genString = new GeradorString();
            GeradorCarisma genCarisma = new GeradorCarisma();
            GeradorDestino genDestino = new GeradorDestino();

            Indole indole = new Indole()
            {
                Nome = genString.GerarTamanhoEspecifico(3, 10, rnd),
                Carisma = genCarisma.Gerar(rnd),
                Destino = genDestino.Gerar(rnd)
            };
            return indole;
        }

        public List<Indole> GerarLista(int quantidade, Random rnd)
        {
            List<Indole> resultado = new List<Indole>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}