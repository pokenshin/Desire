using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    public class GeradorIndole : IGerador<Indole>
    {
        public Indole Gerar()
        {
            GeradorString genString = new GeradorString();
            GeradorCarisma genCarisma = new GeradorCarisma();
            GeradorDestino genDestino = new GeradorDestino();

            Indole indole = new Indole()
            {
                Nome = genString.GerarTamanhoEspecifico(3, 10),
                Carisma = genCarisma.Gerar(),
                Destino = genDestino.Gerar()
            };
            return indole;
        }

        public List<Indole> GerarLista(int quantidade)
        {
            List<Indole> resultado = new List<Indole>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}